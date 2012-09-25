using System;
using System.Runtime.Serialization;
using System.Linq;

namespace Predica.FimCommunication.Errors
{
    [Serializable]
    public class MultipleResourceTypesException : Exception
    {
        public readonly string RequestedTypeName;
        public readonly Type[] Types;

        public MultipleResourceTypesException(string requestedTypeName, Type[] types)
            : base(string.Format("There are mutiple types that can be created for requested type '{0}': '{1}'", 
                requestedTypeName, 
                string.Join(",", types.Select(x => x.FullName).ToArray()))
            )
        {
            RequestedTypeName = requestedTypeName;
            Types = types;
        }

        protected MultipleResourceTypesException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}