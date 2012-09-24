using System;
using System.Collections.Generic;

using Microsoft.ResourceManagement.Client.WsEnumeration;
using Microsoft.ResourceManagement.ObjectModel;

namespace Microsoft.ResourceManagement.Client {
    class EnumerationResultEnumerator : IEnumerator<RmResource>, IEnumerable<RmResource> {
        WsEnumerationClient client;
        List<RmResource> results;
        int resultIndex;
        bool endOfSequence;
        EnumerationContext context;
        String filter;
        String[] attributes;
        RmResource current;
        RmResourceFactory resourceFactory;

        internal EnumerationResultEnumerator(WsEnumerationClient client, RmResourceFactory factory, String filter, String[] attributes) {
            results = new List<RmResource>();
            this.client = client;
            this.filter = filter;
            this.resourceFactory = factory;
            this.attributes = attributes;
        }

        #region IEnumerator<RmResource> Members

        public RmResource Current {
            get { return current; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose() {
            this.context = null;
            this.results.Clear();
            this.results = null;
        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current {
            get { return current; }
        }

        public bool MoveNext() {
            lock (this.client) {
                if (resultIndex < results.Count) {
                    this.current = results[resultIndex++];
                    return true;
                } else {
                    PullResponse response;
                    if (this.context == null) {
                        if (resultIndex > 0) {
                            // case: previous pull returned an invalid context
                            return false;
                        }
                        EnumerationRequest request = new EnumerationRequest(filter);
                        if (attributes != null) {
                            request.Selection = new List<string>();
                            request.Selection.AddRange(this.attributes);
                        }
                        response = client.Enumerate(request);
                        this.endOfSequence = response.EndOfSequence != null;
                    } else {
                        if (this.endOfSequence == true) {
                            // case: previous pull returned an end of sequence flag
                            this.current = null;
                            return false;
                        }
                        PullRequest request = new PullRequest();
                        request.EnumerationContext = this.context;
                        response = client.Pull(request);
                    }

                    if (response == null)
                        return false;
                    resultIndex = 0;
                    this.results = resourceFactory.CreateResource(response);
                    this.context = response.EnumerationContext;
                    this.endOfSequence = response.IsEndOfSequence;
                    if (this.results.Count > 0) {
                        this.current = results[resultIndex++];
                        return true;
                    } else {
                        this.current = null;
                        return false;
                    }
                }
            }
        }

        public void Reset() {
            this.results.Clear();
            this.context = null;
        }

        #endregion

        #region IEnumerable<RmResource> Members

        public IEnumerator<RmResource> GetEnumerator() {
            return this;
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this;
        }

        #endregion
    }
}
