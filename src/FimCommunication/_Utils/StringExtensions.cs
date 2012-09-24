namespace Predica.FimCommunication  
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static bool IsNotNullOrEmpty(this string @this)
        {
            return !@this.IsNullOrEmpty();
        }

        public static string FormatWith(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }

        public static bool DoesNotContain(this string @this, string value)
        {
            return !@this.Contains(value);
        }
    }
}