using System;
using System.Runtime.Serialization;

namespace Predica.FimCommunication.Errors
{
    [Serializable]
    public class QueryExecutionException : Exception
    {
        public QueryExecutionException(string query, Exception inner)
            : base(string.Format("Error when executing query: '{0}'", query), inner)
        {
        }

        protected QueryExecutionException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}