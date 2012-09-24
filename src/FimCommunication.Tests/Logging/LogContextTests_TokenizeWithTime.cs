using System;
using System.Threading;
using Xunit;

namespace Predica.FimCommunication.Tests
{
    public class LogContextTests_TokenizeWithTime
    {
        private static readonly int _timespanLength = TimeSpan.FromSeconds(3).Format().Length;
        private static readonly int _guidLength = Guid.NewGuid().ToString().Length;

        [Fact]
        public void prepends_generated_strings_with_timespan()
        {
            string str = Randomizer.String();
  
            var ctx = new LogContext();
  
            string result = ctx.TokenizeTime(str);

            Assert.Equal('[', result[0]);

            string time = result.Substring(1, _timespanLength);
            Assert.DoesNotThrow(() => TimeSpan.ParseExact(time, TimeSpanExtensions.FORMAT, null));

            Assert.Equal(']', result[_timespanLength + 1]);
            Assert.Equal(' ', result[_timespanLength + 2]);
        }

        [Fact]
        public void strings_generated_later_have_higher_timespan()
        {
            string str = Randomizer.String();
  
            var ctx = new LogContext();
  
            string result1 = ctx.TokenizeTime(str);
            Thread.Sleep(100);
            string result2 = ctx.TokenizeTime(str);

            TimeSpan time1 = TimeSpan.ParseExact(result1.Substring(1, _timespanLength), TimeSpanExtensions.FORMAT, null);
            TimeSpan time2 = TimeSpan.ParseExact(result2.Substring(1, _timespanLength), TimeSpanExtensions.FORMAT, null);

            Assert.True(time2 > time1);
        }

        [Fact]
        public void does_not_break_strings_that_contain_format_placeholders()
        {
            var ctx = new LogContext();

            string formatInput = "abc {0}def {1} xyz";

            string result = ctx.TokenizeTime(formatInput).FormatWith("11", "22");

            Assert.Equal("abc 11def 22 xyz",
                result.Substring(5 + _timespanLength, result.Length - (5 + _guidLength) - (5 + _timespanLength))
            );
        }
    }
}