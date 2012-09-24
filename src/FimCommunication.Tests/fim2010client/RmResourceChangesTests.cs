using System;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Xunit;
using System.Linq;

namespace Predica.FimCommunication.Tests.fim2010client
{
    public class RmResourceChangesTests
    {
        public class modified_functionality
        {
            [Fact]
            public void clearing_single_valued_reference_generates_Delete_operation___otherwise_fim_web_service_throws()
            {
                RmPerson person = new RmPerson
                {
                    Manager = new RmReference("2CFAAD59-A6ED-4A96-91A2-52992361929A")
                };

                var resourceChanges = new RmResourceChanges(person);
                resourceChanges.BeginChanges();

                person.Manager = null;

                var changes = resourceChanges.GetChanges();

                Assert.Equal(1, changes.Count);

                var change = changes.Single();

                Assert.Equal(RmAttributeChangeOperation.Delete, change.Operation);
                Assert.Equal(RmPerson.AttributeNames.Manager.Name, change.Name.Name);
                Assert.Equal(person.Manager, change.Value);
            }

            [Fact]
            public void clearing_single_valued_date_generates_Delete_operation___otherwise_fim_web_service_throws()
            {
                RmPerson person = new RmPerson
                {
                    EmployeeEndDate = new DateTime(2011, 1, 1)
                };

                var resourceChanges = new RmResourceChanges(person);
                resourceChanges.BeginChanges();

                person.EmployeeEndDate = null;

                var changes = resourceChanges.GetChanges();

                Assert.Equal(1, changes.Count);

                var change = changes.Single();

                Assert.Equal(RmAttributeChangeOperation.Delete, change.Operation);
                Assert.Equal(RmPerson.AttributeNames.EmployeeEndDate.Name, change.Name.Name);
                Assert.Equal(person.EmployeeEndDate, change.Value);
            }
        }

        public class original_functionality
        {
            [Fact]
            public void modifying_single_value_generates_Replace_operation()
            {
                RmPerson person = new RmPerson
                    {
                        DisplayName = "original-name"
                    };

                var resourceChanges = new RmResourceChanges(person);
                resourceChanges.BeginChanges();

                person.DisplayName = "new-name";
                person.LastName = "last name";

                var changes = resourceChanges.GetChanges();

                Assert.Equal(2, changes.Count);
                Assert.NotEmpty(changes.Where(x =>
                                              x.Name.Name == RmPerson.AttributeNames.LastName.Name
                                              && x.Value.ToString() == "last name")
                    );
                Assert.NotEmpty(changes.Where(x =>
                                              x.Name.Name == RmResource.AttributeNames.DisplayName.Name
                                              && x.Value.ToString() == "new-name")
                    );
                foreach (var change in changes)
                {
                    Assert.Equal(RmAttributeChangeOperation.Replace, change.Operation);
                }
            }

            [Fact]
            public void setting_single_valued_reference_generates_Replace_operation()
            {
                RmPerson person = new RmPerson();

                var resourceChanges = new RmResourceChanges(person);
                resourceChanges.BeginChanges();

                person.Manager = new RmReference("2CFAAD59-A6ED-4A96-91A2-52992361929A");

                var changes = resourceChanges.GetChanges();

                Assert.Equal(1, changes.Count);

                var change = changes.Single();

                Assert.Equal(RmAttributeChangeOperation.Replace, change.Operation);
                Assert.Equal(RmPerson.AttributeNames.Manager.Name, change.Name.Name);
                Assert.Equal(person.Manager, change.Value);
            }
        }
    }
}