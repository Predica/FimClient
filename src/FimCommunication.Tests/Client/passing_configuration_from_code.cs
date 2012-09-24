using System;
using Microsoft.ResourceManagement.ObjectModel;
using Predica.FimCommunication.Errors;
using Xunit;

namespace Predica.FimCommunication.Tests.Client
{
    public class passing_configuration_from_code___correct
        : FimIntegrationTestBase
    {
        protected override FimClient CreateClient()
        {
            return new FimClient("http://localhost");
        }

        [Fact]
        public void honors_url_passed_in_fimclient_ctor()
        {
            var people = _client.EnumerateAll<RmResource>("/Person");
            Assert.NotEmpty(people);
        }
    }

    public class passing_configuration_from_code___incorrect
        : FimIntegrationTestBase
    {
        private Exception _initializationException;

        protected override FimClient CreateClient()
        {
            try
            {
                return new FimClient("http://some-incorrect-url");
            }
            catch (Exception exc)
            {
                _initializationException = exc;

                return null;
            }
        }

        [Fact]
        public void honors_url_passed_in_fimclient_ctor()
        {
            // client failed during initialization - it was the first client used in tests suite
            // and it failed when trying to fetch schema
            if (_client == null)
            {
                Assert.NotNull(_initializationException);
            }
            // schema was fetched before so it is created successfully
            else
            {
                Assert.Throws<QueryExecutionException>(() => _client.EnumerateAll<RmResource>("/Person"));
            }
        }
    }
}