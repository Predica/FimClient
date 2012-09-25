using System;
using Microsoft.ResourceManagement.ObjectModel;
using Xunit;

namespace Predica.FimCommunication.Tests.Client
{
    public class disposing_client
        : FimIntegrationTestBase
    {
        [Fact]
        public void throws_if_used_after_disposing()
        {
            _client.Dispose();

            Assert.Throws<ObjectDisposedException>(() => _client.EnumerateAll<RmResource>("some query"));
        }
    }
}