using System;

namespace Predica.FimCommunication  
{
    public static class TimeSpanExtensions
    {
        public const string FORMAT = @"hh\:mm\:ss\.fff";

        public static string Format(this TimeSpan @this)
        {
            return @this.ToString(FORMAT);
        }
    }
}