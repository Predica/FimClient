using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Xml.Schema;
using Microsoft.ResourceManagement.Client;
using Microsoft.ResourceManagement.Client.CodeInit;
using Microsoft.ResourceManagement.Client.WsEnumeration;
using Microsoft.ResourceManagement.ObjectModel;
using System;
using NLog;
using Predica.FimCommunication.Errors;
using Predica.FimCommunication.Querying;

namespace Predica.FimCommunication
{
    public interface IFimClient
    {
        IEnumerable<TResource> EnumerateAll<TResource>(string query, AttributesToFetch attributes = null) where TResource : RmResource;
        DataPage<TResource> EnumeratePage<TResource>(string query, Pagination pagination, SortingInstructions sorting, AttributesToFetch attributes = null) where TResource : RmResource;
        // no generic TResource here
        // we do not always need to know beforehand what type of resource will get fetched by id
        RmResource FindById(string id, AttributesToFetch attributes = null);
        void Create(RmResource newResource);
        bool Delete(RmResource resource);
        bool Update(RmResourceChanges changes);
    }

    public class FimClient : IFimClient
    {
        private DefaultClient _defaultClient;
        private WsEnumerationClient _pagedQueriesClient;

        private readonly string _fimUrl;
        private readonly NetworkCredential _credential;

        public FimClient(string fimUrl = null, NetworkCredential credential = null)
        {
            _fimUrl = fimUrl;
            _credential = credential;
            Initialize();
        }

        #region Initialization

        private static volatile XmlSchemaSet _schema;
        private static readonly object _schemaSyncRoot = new object();

        private readonly object _initializationSyncRoot = new object();
        private bool _isInitialized = false;

        private void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }
            lock (_initializationSyncRoot)
            {
                if (_isInitialized)
                {
                    return;
                }

                var ctx = LogContext.WithConfigFormat();

                _log.Debug(ctx.Format("Initializing FIM client for user {0}"), System.Threading.Thread.CurrentPrincipal.Identity.Name);

                // client used for paged queries
                _pagedQueriesClient = _fimUrl == null
                    ? new WsEnumerationClient()
                    : new WsEnumerationClient(Bindings.ServiceMultipleTokenBinding_Common, DefaultEndpoints.WsEnumeration(_fimUrl));

                // client used for all other operations
                _defaultClient = _fimUrl == null
                    ? new DefaultClient()
                    : new DefaultClient(_fimUrl);

                if (_credential != null)
                {
                    _pagedQueriesClient.ClientCredentials.Windows.ClientCredential = _credential;
                    _defaultClient.ClientCredential = _credential;
                }

                // reusing schema for all subsequent instances for performance reasons
                // each schema-refresh operation downloads ~1MB of xml that never changes
                if (_schema == null)
                {
                    lock (_schemaSyncRoot)
                    {
                        if (_schema == null)
                        {
                            _log.Debug(ctx.Format("Downloading FIM schema..."));

                            _schema = _defaultClient.RefreshSchema();

                            _log.Debug(ctx.Format("FIM schema downloaded"));
                        }
                    }
                }

                var resourceTypeFactory = CreateResourceTypeFactory();
                _defaultClient.ResourceFactory = new RmResourceFactory(_schema, resourceTypeFactory);
                _defaultClient.RequestFactory = new RmRequestFactory(_schema);

                _isInitialized = true;

                _log.Debug(ctx.Format("FIM client initialized for user {0}"), System.Threading.Thread.CurrentPrincipal.Identity.Name);
            }
        }

        protected virtual IResourceTypeFactory CreateResourceTypeFactory()
        {
            return new DefaultResourceTypeFactory();
        }

        #endregion

        #region Enumeration

        /// <summary>
        /// Adds information about finished operaiton to logs.
        /// If operation is short - adds with DEBUG level.
        /// If operation is long (> than config.FimLongQueryMilliseconds) adds with WARN level.
        /// </summary>
        private void log_query_executed(LogContext ctx, string msg, params object[] formatArguments)
        {
            long longOperationMilliseconds = get_configured_long_operation_duration();

            if (ctx.Elapsed.TotalMilliseconds >= longOperationMilliseconds)
            {
                _log.Warn(ctx.Format(msg), formatArguments);
            }
            else
            {
                _log.Debug(ctx.Format(msg), formatArguments);
            }
        }

        #region long_operation_milliseconds

        private const long DEFAULT_LONG_OPERATION_DURATION_MILLISECONDS = 2500;
        private static long? _long_operation_milliseconds;
        private static object _long_operation_sync_root = new object();

        private long get_configured_long_operation_duration()
        {
            if (_long_operation_milliseconds == null)
            {
                lock (_long_operation_sync_root)
                {
                    if (_long_operation_milliseconds == null)
                    {
                        long longOperationMilliseconds;
                        if (long.TryParse(ConfigurationManager.AppSettings["FimLongQueryMilliseconds"], out longOperationMilliseconds))
                        {
                            _long_operation_milliseconds = longOperationMilliseconds;
                        }
                        else
                        {
                            _long_operation_milliseconds = DEFAULT_LONG_OPERATION_DURATION_MILLISECONDS;
                        }
                    }
                }
            }

            return _long_operation_milliseconds.Value;
        }

        #endregion

        public IEnumerable<TResource> EnumerateAll<TResource>(string query, AttributesToFetch attributes = null) where TResource : RmResource
        {
            attributes = attributes ?? AttributesToFetch.All;

            var ctx = LogContext.WithConfigFormat();

            try
            {
                Initialize();

                _log.Debug(ctx.Format("Executing simple enumeration: {0} with attributes {1}"), query, attributes.GetNames().ToJSON());

                var results = _defaultClient.Enumerate(query, attributes.GetNames())
                    .Cast<TResource>()
                    .ToList();

                log_query_executed(ctx, "Simple enumeration {0} returned {1} results", query, results.Count);

                return results;
            }
            catch (Exception exc)
            {
                var qee = new QueryExecutionException(query, exc);

                _log.ErrorException(ctx.Format("Error when trying to execute query " + query), qee);

                throw qee;
            }
        }

        public DataPage<TResource> EnumeratePage<TResource>(string query, Pagination pagination, SortingInstructions sorting, AttributesToFetch attributes = null) where TResource : RmResource
        {
            if (pagination == null)
            {
                throw new ArgumentNullException("pagination");
            }
            if (sorting == null)
            {
                throw new ArgumentNullException("sorting");
            }

            try
            {
                return ExecuteAdjustedQuery<TResource>(query, pagination, sorting, attributes);
            }
            catch (Exception exc)
            {
                var qee = new QueryExecutionException(query, exc);

                _log.ErrorException("Error when trying to execute query " + query, qee);

                throw qee;
            }
        }

        private DataPage<TResource> ExecuteAdjustedQuery<TResource>(string query, Pagination pagination, SortingInstructions sorting, AttributesToFetch attributes = null) where TResource : RmResource
        {
            attributes = attributes ?? AttributesToFetch.All;

            Initialize();

            var ctx = LogContext.WithConfigFormat();

            _log.Debug(ctx.Format("Executing query {0} with paging: {1}, sorting {2} and attributes {3}"), query, pagination.ToJSON(), sorting.ToJSON(), attributes.GetNames().ToJSON());

            // first request - only to get enumeration context and total rows count
            var enumerationRequest = new EnumerationRequest(query);
            // do not fetch any items - total count only; however this cannot be set to 0 because then total count is not returned (is always set to 0)
            enumerationRequest.MaxElements = 1;
            // get only ObjectID attribute to minimize overhead caused by this operation which returns elements not used for further processing
            enumerationRequest.Selection = new List<string>
                {
                    RmResource.AttributeNames.ObjectID.Name
                };
            var enumerateResponse = _pagedQueriesClient.Enumerate(enumerationRequest);

            long totalCount = enumerateResponse.Count ?? 0;

            // second request - to actually get desired data
            var pullRequest = new PullRequest();
            // set enumeration context from previous query
            pullRequest.EnumerationContext = enumerateResponse.EnumerationContext;
            
            // if attributes names to fetch defined...
            var attributeNames = attributes.GetNames();
            if (attributeNames != null)
            {
                // ... set them to context
                pullRequest.EnumerationContext.Selection = new Selection();
                pullRequest.EnumerationContext.Selection.@string = attributeNames.ToList();
            }
            else
            {
                pullRequest.EnumerationContext.Selection = null;
            }

            // if paging defined...
            if (pagination.PageSize != Pagination.AllPagesSize)
            {
                // set current page's first row index...
                pullRequest.EnumerationContext.CurrentIndex = pagination.GetFirstRowIndex();
                // ...and page size
                pullRequest.MaxElements = pagination.PageSize;
            }
            // ... if not - get all elements
            else
            {
                // reset current row index...
                pullRequest.EnumerationContext.CurrentIndex = 0;
                // ... page size to max (this may throw if message size exceeds configured maximum, but this situation - getting all items using this method - is not likely to happen)
                pullRequest.MaxElements = int.MaxValue;
            }

            // if sorting defined...
            if (sorting != SortingInstructions.None)
            {
                var sortingAttribute = new SortingAttribute()
                    {
                        Ascending = sorting.Order == SortOrder.Ascending,
                        Value = sorting.AttributeName
                    };
                // due to implementation details of these classes, new instances of each of them needs to be created
                pullRequest.EnumerationContext.Sorting = new Sorting
                    {
                        SortingAttribute = new List<SortingAttribute>
                            {
                                sortingAttribute
                            }
                    };
            }

            var pullResponse = _pagedQueriesClient.Pull(pullRequest);
            var results = _defaultClient.ResourceFactory.CreateResource(pullResponse)
                .Cast<TResource>()
                .ToList();

            log_query_executed(ctx, "Paged query {0} returned {1} results and {2} total count", query, results.Count, totalCount);

            return new DataPage<TResource>(results, totalCount);
        }

        #endregion

        public void Create(RmResource newResource)
        {
            Initialize();

            _log.Info("Creating resource of type {0}", newResource.ObjectType);

            _defaultClient.Create(newResource);
        }

        public bool Update(RmResourceChanges changes)
        {
            Initialize();

            int changesCount = changes.GetChanges().Count;
            if (changesCount == 0)
            {
                _log.Debug("Requested to update resource {0} of type {1} but no changes are present. Aborting.", changes.RmObject.ObjectID.Value, changes.RmObject.ObjectType);
                return true;
            }

            _log.Info("Updating resource {0} of type {1} with {2} changes", changes.RmObject.ObjectID.Value, changes.RmObject.ObjectType, changesCount);

            bool updated = _defaultClient.Put(changes);
            changes.AcceptChanges();

            return updated;
        }

        public bool Delete(RmResource resource)
        {
            Initialize();

            _log.Info("Deleting resource {0} of type {1}", resource.ObjectID.Value, resource.ObjectType);

            bool deleted = false;
            try
            {
                deleted = _defaultClient.Delete(resource.ObjectID);
            }
            catch
            {
                // catching exc - meaning that object not found

                _log.Warn("Could not delete object with id {0} not found", resource.ObjectID.Value);
            }
            return deleted;
        }

        public RmResource FindById(string id, AttributesToFetch attributes = null)
        {
            Initialize();

            attributes = attributes ?? AttributesToFetch.All;

            var ctx = LogContext.WithConfigFormat();

            _log.Debug(ctx.Format("Finding object by id {0} with attributes {1}"), id, attributes.GetNames().ToJSON());

            RmResource resource = null;

            try
            {
                var reference = new RmReference(id);

                if (attributes != AttributesToFetch.All)
                {
                    attributes = attributes.AppendAttribute(RmResource.AttributeNames.ObjectType.Name);
                }

                resource = _defaultClient.Get(reference, attributes.GetNames());

                _log.Debug(ctx.Format("Found object with id {0}, type {1}"), id, resource.ObjectType);
            }
            catch
            {
                // catching exc - meaning that object not found

                _log.Warn(ctx.Format("Object with id {0} not found"), id);
            }
            return resource;
        }

        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
    }
}