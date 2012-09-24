using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
//using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.ResourceManagement.Client.Faults;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.Client.WsTrust;

namespace Microsoft.ResourceManagement.Client.WsTransfer
{
    public class AlternateClient : System.ServiceModel.ClientBase<IAlternate>, IAlternate
    {
        public AlternateClient()
            : base()
        {

        }
        public AlternateClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public AlternateClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AlternateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AlternateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Message Get(Message request)
        {
            IResource channel = base.ChannelFactory.CreateChannel();
            IContextManager contextManger = ((IClientChannel)channel).GetProperty<IContextManager>();
            contextManger.Enabled = false;

            return channel.Get(request);
        }
        
        public GetResponse Get(GetRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            Message getRequest = null;
            bool isBaseObjectSearchRequest = false;
            lock (request)
            {
                if (request.BaseObjectSearchRequest == null || request.BaseObjectSearchRequest.AttributeTypes.Count == 0)
                {
                    getRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.GetAction);
                }
                else
                {
                    isBaseObjectSearchRequest = true;
                    getRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.GetAction, request.BaseObjectSearchRequest, new ClientSerializer(typeof(BaseObjectSearchRequest)));
                    ClientHelper.AddImdaHeaders(request as ImdaRequest, getRequest);
                }

                ClientHelper.AddRmHeaders(request as WsTransfer.TransferRequest, getRequest);
            }
            Message getResponse = Get(getRequest);
            if(getResponse.IsFault)
            {
                // handle fault will throw a .NET exception
                ClientHelper.HandleFault(getResponse);
            }

            GetResponse getResponseTyped = new GetResponse();
            if(isBaseObjectSearchRequest)
            {
                BaseObjectSearchResponse baseObjectSearchResponse = getResponse.GetBody<BaseObjectSearchResponse>(new ClientSerializer(typeof(BaseObjectSearchResponse)));
                getResponseTyped.BaseObjectSearchResponse = baseObjectSearchResponse;
            }
            else
            {
                // we manually construct the partial attributes as if the client had selected all attributes
                // the purpose is to unify the API of the get request
                XmlNode retObject = getResponse.GetBody<XmlNode>(new ClientSerializer(typeof(XmlNode)));
                Dictionary<String, List<XmlNode>> seenAttributes = new Dictionary<string, List<XmlNode>>();
                foreach (XmlNode child in retObject.ChildNodes)
                {
                    if (child.NodeType == XmlNodeType.Element)
                    {
                        if (seenAttributes.ContainsKey(child.Name) == false)
                        {
                            seenAttributes[child.Name] = new List<XmlNode>();
                        }
                        seenAttributes[child.Name].Add(child);
                    }
                }

                getResponseTyped.BaseObjectSearchResponse = new BaseObjectSearchResponse();
                foreach (KeyValuePair<String, List<XmlNode>> item in seenAttributes)
                {
                    PartialAttributeType partialAttribute = new PartialAttributeType();
                    partialAttribute.Values.AddRange(item.Value);
                }
            }
            return getResponseTyped;
        }
        
        public Message Put(Message request)
        {
            IResource channel = base.ChannelFactory.CreateChannel();
            IContextManager contextManger = ((IClientChannel)channel).GetProperty<IContextManager>();
            contextManger.Enabled = false;

            return channel.Put(request);
        }
        public Message Put(Message request, SecurityToken token)
        {
            WsTransferClient client = new WsTransferClient(
                new ClientMultipleTokenBinding(),
                this.Endpoint.Address);

            client.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
            client.Endpoint.Behaviors.Add(new TokenAndClientCredentials(token));

            client.ClientCredentials.Windows.ClientCredential = this.ClientCredentials.Windows.ClientCredential;

            IResource channel = client.ChannelFactory.CreateChannel();
            IContextManager contextManger = ((IClientChannel)channel).GetProperty<IContextManager>();
            contextManger.Enabled = false;
 
            using (channel as IDisposable)
            {
                return channel.Put(request);
            }
        }

        public PutResponse Put(PutRequest request)
        {
            PutResponse response;

            Put(request, out response);

            // the response has no information if it isn't a fault
            // PutResponse putResponseTyped = putResponse.GetBody<PutResponse>(new ClientSerializer(typeof(PutResponse)));
            return response;
        }

        public PutResponse Put(PutRequest request, SamlSecurityToken token)
        {
            PutResponse response;

            Put(request, out response, token);

            // the response has no information if it isn't a fault
            // PutResponse putResponseTyped = putResponse.GetBody<PutResponse>(new ClientSerializer(typeof(PutResponse)));
            return response;
        }

        public void Put(PutRequest request, out PutResponse response)
        {

            Put(request, out response, null);

        }

        public void Put(PutRequest request, out PutResponse response, SecurityToken token)
        {
            Put(request, out response, token, null);
        }

        public void Put(PutRequest request, out PutResponse response, SecurityToken token, ContextMessageProperty context)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (request.ModifyRequest == null)
            {
                throw new ArgumentNullException("ModifyRequest");
            }
            if (request.ResourceReferenceProperty == null)
            {
                throw new ArgumentNullException("ResourceReferenceProperty");
            }

            Message putRequest = null;
            Message putResponse = null;
            lock (request)
            {
                putRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.PutAction, request.ModifyRequest, new ClientSerializer(typeof(ModifyRequest)));
                ClientHelper.AddImdaHeaders(request as ImdaRequest, putRequest);
                ClientHelper.AddRmHeaders(request as WsTransfer.TransferRequest, putRequest);
                if (context != null)
                {
                    context.AddOrReplaceInMessage(putRequest);
                }
            }

            if (token == null)
            {
                putResponse = Put(putRequest);
                response = new PutResponse(putResponse);
            }
            else
            {
                putResponse = Put(putRequest,token);
                response = new PutResponse(putResponse);
            }
            if (putResponse.IsFault)
            {
                ClientHelper.HandleFault(putResponse);
            }

            // the response has no information if it isn't a fault
            // PutResponse putResponseTyped = putResponse.GetBody<PutResponse>(new ClientSerializer(typeof(PutResponse)));
        }

        public Message Delete(Message request)
        {
            IResource channel = base.ChannelFactory.CreateChannel();
            return channel.Delete(request);
        }

        public DeleteResponse Delete(DeleteRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (request.ResourceReferenceProperty == null)
            {
                throw new ArgumentNullException("ResourceReferenceProperty");
            }
            Message deleteRequest = null;
            lock (request)
            {
                deleteRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.DeleteAction, request, new ClientSerializer(typeof(DeleteRequest)));
                ClientHelper.AddRmHeaders(request as WsTransfer.TransferRequest, deleteRequest);
            }
            Message deleteResponse = Delete(deleteRequest);
            if (deleteResponse.IsFault)
            {
                ClientHelper.HandleFault(deleteResponse);
            }

            // the response has no information if it isn't a fault
            // return deleteResponse.GetBody<DeleteResponse>(new ClientSerializer(typeof(DeleteResponse)));
            return new DeleteResponse();
        }
    }
}
