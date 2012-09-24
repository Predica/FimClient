namespace Predica.FimCommunication.Tests
{
    public abstract class FimIntegrationTestBase
    {
        protected FimClient _client;

        protected FimIntegrationTestBase()
        {
            _client = CreateClient();
        }

        protected virtual FimClient CreateClient()
        {
            return new FimClient();
        }
    }
}