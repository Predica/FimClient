using System;
using Xunit;

namespace Predica.FimCommunication.Tests
{
    public class LogContextTests_Format
    {
        private static readonly int _timespanLength = TimeSpan.FromSeconds(3).Format().Length;
        private static readonly int _guidLength = Guid.NewGuid().ToString().Length;

        [Fact]
        public void uses_format_to_inject_timespan_in_strings()
        {
            string str = Randomizer.String();

            var ctx = new LogContext("{elapsed} [x] {message}");

            string result = ctx.Format(str);

            string time = result.Substring(0, _timespanLength);
            Assert.DoesNotThrow(() => TimeSpan.ParseExact(time, TimeSpanExtensions.FORMAT, null));

            string x = result.Substring(time.Length, 5);
            Assert.Equal(" [x] ", x);

            string msg = result.Substring(time.Length + x.Length);
            Assert.Equal(str, msg);
        }

        [Fact]
        public void uses_format_to_inject_guid_in_strings()
        {
            string str = Randomizer.String();

            var ctx = new LogContext("{token} [x] {message}");

            string result = ctx.Format(str);

            string token = result.Substring(0, _guidLength);
            Assert.DoesNotThrow(() => Guid.Parse(token));

            string x = result.Substring(token.Length, 5);
            Assert.Equal(" [x] ", x);

            string msg = result.Substring(token.Length + x.Length);
            Assert.Equal(str, msg);
        }

        [Fact]
        public void does_not_break_strings_that_contain_format_placeholders()
        {
            var ctx = new LogContext("prefix {message} middle {elapsed} | {token} suffix");

            string formatInput = "abc {0}def {1} xyz";

            string result = ctx.Format(formatInput).FormatWith("11", "22");

            string expectedStart = "prefix abc 11def 22 xyz middle ";

            Assert.True(result.StartsWith(expectedStart));
            
            Assert.DoesNotThrow(() => TimeSpan.ParseExact(result.Substring(expectedStart.Length, _timespanLength), TimeSpanExtensions.FORMAT, null));

            Assert.Equal(" | ", result.Substring(expectedStart.Length + _timespanLength, 3));

            Assert.DoesNotThrow(() => Guid.Parse(result.Substring(expectedStart.Length + _timespanLength + 3, _guidLength)));

            Assert.True(result.EndsWith(" suffix"));
        }
    }
}