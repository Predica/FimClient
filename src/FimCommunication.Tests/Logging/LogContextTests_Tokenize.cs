using System;
using Xunit;
using Xunit.Extensions;

namespace Predica.FimCommunication.Tests
{
    public class LogContextTests_Tokenize
    {
        private static readonly int _guidLength = Guid.NewGuid().ToString().Length;

        [Fact]
        public void appends_pipe_with_guid_to_generated_strings()
        {
            string str = Randomizer.String();

            var ctx = new LogContext();

            string result = ctx.Tokenize(str);

            string beforeToken = result.Substring(0, str.Length);
            Assert.Equal(str, beforeToken);

            Assert.Equal(' ', result[str.Length]);

            Assert.Equal('|', result[str.Length + 1]);
            Assert.Equal(' ', result[str.Length + 2]);

            Assert.Equal('[', result[str.Length + 3]);

            string token = result.Substring(str.Length + 4, _guidLength);
            Assert.DoesNotThrow(() => Guid.Parse(token));

            Assert.Equal(']', result[str.Length + 3 + _guidLength + 1]);
        }

        [Fact]
        public void one_instance_uses_one_guid_for_all_strings()
        {
            string str1 = Randomizer.String();
            string str2 = Randomizer.String();

            var ctx = new LogContext();

            string result1 = ctx.Tokenize(str1);
            string result2 = ctx.Tokenize(str2);
            string result3 = ctx.Tokenize(str2);

            Guid token1 = Guid.Parse(result1.Substring(str1.Length + 4, _guidLength));
            Guid token2 = Guid.Parse(result2.Substring(str2.Length + 4, _guidLength));

            Assert.Equal(token1, token2);

            Assert.Equal(result2, result3);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void returns_only_tokens_for_empty_and_nulls(string p)
        {
            var ctx = new LogContext();
            string result = ctx.Tokenize(p);

            Assert.Equal('[', result[0]);
            Assert.DoesNotThrow(() => Guid.Parse(result.Substring(1, _guidLength)));
            Assert.Equal(']', result[result.Length - 1]);
        }

        [Fact]
        public void does_not_break_strings_that_contain_format_placeholders()
        {
            var ctx = new LogContext();

            string formatInput = "abc {0}def {1} xyz";

            string result = ctx.Tokenize(formatInput).FormatWith("11", "22");

            Assert.Equal("abc 11def 22 xyz", result.Substring(0, result.Length - (5 + _guidLength)));
        }
    }
}