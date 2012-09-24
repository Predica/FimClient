using System.Collections.Generic;
using Microsoft.ResourceManagement.Client;
using Microsoft.ResourceManagement.ObjectModel;
using Xunit;
using System.Linq;

namespace Predica.FimCommunication.Tests.Client.Initialization
{
    public class replacing_resource_type_factory
        : FimIntegrationTestBase
    {
        private custom_resource_type_factory _customResourceTypeFactory;

        protected override FimClient CreateClient()
        {
            var client = new stub_client_with_custom_factory();

            _customResourceTypeFactory = client.CustomResourceTypeFactory;

            return client;
        }

        #region stub client

        public class stub_client_with_custom_factory
            : FimClient
        {
            public custom_resource_type_factory CustomResourceTypeFactory;

            protected override IResourceTypeFactory CreateResourceTypeFactory()
            {
                CustomResourceTypeFactory = new custom_resource_type_factory();

                return CustomResourceTypeFactory;
            }
        }

        #endregion

        #region stub factory

        public class custom_resource_type_factory
            : IResourceTypeFactory
        {
            public readonly List<string> CalledResources = new List<string>();

            public RmResource CreateResource(string resourceType)
            {
                CalledResources.Add(resourceType);

                return new RmResource();
            }
        }

        #endregion

        [Fact]
        public void fimclient_children_can_use_custom_resource_type_factory_to_create_resources()
        {
            var persons = _client.EnumerateAll<RmResource>("/Person")
                .ToList();
            var workflows = _client.EnumerateAll<RmResource>("/WorkflowDefinition")
                .ToList();

            var expectedResourceCalls = new List<string>();
            expectedResourceCalls.AddRange(Enumerable.Repeat("Person", persons.Count));
            expectedResourceCalls.AddRange(Enumerable.Repeat("WorkflowDefinition", workflows.Count));

            Assert.Equal(expectedResourceCalls, _customResourceTypeFactory.CalledResources);
        }
    }
}