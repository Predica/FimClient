using System;
using System.Linq;
using System.ServiceModel;

namespace Microsoft.ResourceManagement.Client.CodeInit
{
    public static class DefaultEndpoints
    {
        public static EndpointAddress WsEnumeration(string fimServiceUrl)
        {
            var parsingResult = ParseFimUrl(fimServiceUrl);

            return new EndpointAddress(new Uri(parsingResult.ParsedUrl + Constants.Endpoint.Enumeration), new SpnEndpointIdentity(Constants.Addressing.SpnPrefix + parsingResult.Spn));
        }

        public static EndpointAddress Alternate(string fimServiceUrl)
        {
            var parsingResult = ParseFimUrl(fimServiceUrl);

            return new EndpointAddress(new Uri(parsingResult.ParsedUrl + Constants.Endpoint.Alternate));
        }

        public static EndpointAddress Mex(string fimServiceUrl)
        {
            var parsingResult = ParseFimUrl(fimServiceUrl);

            return new EndpointAddress(new Uri(parsingResult.ParsedUrl + Constants.Endpoint.Mex));
        }

        public static EndpointAddress WsTransfer(string fimServiceUrl)
        {
            var parsingResult = ParseFimUrl(fimServiceUrl);

            return new EndpointAddress(new Uri(parsingResult.ParsedUrl + Constants.Endpoint.Resource), new SpnEndpointIdentity(Constants.Addressing.SpnPrefix + parsingResult.Spn));
        }

        public static EndpointAddress WsTransferFactory(string fimServiceUrl)
        {
            var parsingResult = ParseFimUrl(fimServiceUrl);

            return new EndpointAddress(new Uri(parsingResult.ParsedUrl + Constants.Endpoint.ResourceFactory), new SpnEndpointIdentity(Constants.Addressing.SpnPrefix + parsingResult.Spn));
        }

        private class FimUrlParsingResult
        {
            public string ParsedUrl { get; set; }
            public string Spn { get; set; }
        }

        private static FimUrlParsingResult ParseFimUrl(string fimServiceUrl)
        {
            var result = new FimUrlParsingResult();

            result.ParsedUrl = (fimServiceUrl.EndsWith("/")
                ? fimServiceUrl.Remove(fimServiceUrl.Length)
                : fimServiceUrl)
                + Constants.Addressing.FimPort + "/";

            result.Spn = fimServiceUrl.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (result.Spn.EndsWith("/"))
            {
                result.Spn = result.Spn.Remove(result.Spn.LastIndexOf('/'));
            }

            return result;
        }
    }
}