using System.Web.Script.Serialization;

namespace Predica.FimCommunication
{
    public static class ObjectExtensions
    {
        private static readonly JavaScriptSerializer _jsonSerializer = new JavaScriptSerializer();
        public static string ToJSON(this object @this)
        {
            return _jsonSerializer.Serialize(@this);
        } 
    }
}