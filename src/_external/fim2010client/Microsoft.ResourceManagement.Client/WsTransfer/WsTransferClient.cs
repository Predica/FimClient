using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.Client.Faults;

namespace Microsoft.ResourceManagement.Client.WsTransfer
{
    public class WsTransferClient : System.ServiceModel.ClientBase<IResource>, IResource
    {
        public WsTransferClient()
            : base()
        {
        }

        public WsTransferClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public WsTransferClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public WsTransferClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public WsTransferClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Message Get(Message request) {
            // PATCHED: handle the channel's faulted state (avoid the using 
            // statement)
            return this.CallChannelMethod((channel) => channel.Get(request));
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
                    getResponseTyped.BaseObjectSearchResponse.PartialAttributes.Add(partialAttribute);
                }
            }
            return getResponseTyped;
        }
        
        public Message Put(Message request)
        {
            IResource channel = base.ChannelFactory.CreateChannel();
            IContextManager contextManger = ((IClientChannel)channel).GetProperty<IContextManager>();
            contextManger.Enabled = false;

            // PATCHED: handle the channel's faulted state (avoid the using 
            // statement)
            //return this.CallChannelMethod((channel) => channel.Put(request));
            //TODO: Revert change below back to pattern this.CallChannelMethod while preservig code above to disable ContextManagement
#warning Help needed here from Paolo
            return channel.Put(request);

        }

        public PutResponse Put(PutRequest request)
        {
            PutResponse response;

            Put(request, out response);
            
            // the response has no information if it isn't a fault
            // PutResponse putResponseTyped = putResponse.GetBody<PutResponse>(new ClientSerializer(typeof(PutResponse)));
            return response;
        }

        public void Put(PutRequest request, out PutResponse response)
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
            lock (request)
            {
                putRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.PutAction, request.ModifyRequest, new ClientSerializer(typeof(ModifyRequest)));
                ClientHelper.AddImdaHeaders(request as ImdaRequest, putRequest);
                ClientHelper.AddRmHeaders(request as WsTransfer.TransferRequest, putRequest);
            }
            Message putResponse = Put(putRequest);
            response = new PutResponse(putResponse);
            if (putResponse.IsFault)
            {
                ClientHelper.HandleFault(putResponse);
            }

            // the response has no information if it isn't a fault
            // PutResponse putResponseTyped = putResponse.GetBody<PutResponse>(new ClientSerializer(typeof(PutResponse)));
        }

        public Message Delete(Message request) {
            // PATCHED: handle the channel's faulted state (avoid the using 
            // statement)
            return this.CallChannelMethod((channel) => channel.Delete(request));
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
