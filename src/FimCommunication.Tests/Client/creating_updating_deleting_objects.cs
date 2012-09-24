using System.Linq;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Xunit;

namespace Predica.FimCommunication.Tests.Client
{
    public class creating_updating_deleting_objects
        : FimIntegrationTestBase
    {
        [Fact]
        public void creates_new_person()
        {
            var person = new RmPerson();
            person.FirstName = "new person first name";
            person.DisplayName = "_new person display name";

            _client.Create(person);
            var newId = person.ObjectID;

            var newPerson = _client.FindById(newId.Value);

            Assert.NotNull(newPerson);
            Assert.NotNull(person.ObjectID);

            _client.Delete(person);
        }

        [Fact]
        public void deletes_person()
        {
            var person = new RmPerson();
            _client.Create(person);

            var newPerson = _client.FindById(person.ObjectID.Value);
            Assert.NotNull(newPerson);

            var deleted = _client.Delete(person);

            newPerson = _client.FindById(person.ObjectID.Value);
            Assert.Null(newPerson);

            Assert.True(deleted);
        }

        [Fact]
        public void delete_does_not_throw_for_nonexisting_objects()
        {
            var person = new RmPerson();
            person.ObjectID = new RmReference("3F7D3306-26FD-4DDB-9DCC-09289A3CE45D");

            Assert.DoesNotThrow(() => _client.Delete(person));
        }

        [Fact]
        public void does_not_throw_when_no_changes_to_send()
        {
            var person = _client.EnumerateAll<RmResource>("/Person")
                .First();

            var changes = new RmResourceChanges(person);
            changes.BeginChanges();

            _client.Update(changes);
        }

        [Fact]
        public void can_clear_reference_on_update()
        {
            var person = _client.EnumerateAll<RmPerson>("/Person").First();

            var newPerson = new RmPerson()
                {
                    DisplayName = "___",
                };
            _client.Create(newPerson);

            var changes = new RmResourceChanges(newPerson);
            changes.BeginChanges();
            newPerson.Manager = person.ObjectID;

            _client.Update(changes);

            changes = new RmResourceChanges(newPerson);
            changes.BeginChanges();
            newPerson.Manager = null;

            Assert.DoesNotThrow(() =>
                {
                    _client.Update(changes);
                });

            _client.Delete(newPerson);
        }
    }
}