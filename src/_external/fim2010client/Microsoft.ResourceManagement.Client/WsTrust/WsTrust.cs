using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Xml.Serialization;
using Microsoft.IdentityModel.Protocols.WSTrust;
//using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;

namespace Microsoft.ResourceManagement.Client.WsTrust {
    public class WsTrust {
        public static RequestSecurityToken RequestFIMSTSToken(String endpointAddress, String userName) {
            byte[] entropy = Guid.NewGuid().ToByteArray();
            RequestSecurityToken rst = new RequestSecurityToken(Microsoft.IdentityModel.SecurityTokenService.RequestTypes.Issue);
            rst.AppliesTo = new EndpointAddress(endpointAddress);
            rst.Entropy = new Entropy(entropy as byte[]);
            rst.ActAs = new Microsoft.IdentityModel.Tokens.SecurityTokenElement(new UserNameSecurityToken(userName, String.Empty));
            //XmlSerializer x = new XmlSerializer(typeof(RequestSecurityToken));
            //x.Serialize(.Runtime.Serialization. xml = System.Runtime.Serialization.XmlObjectSerializer(
            //RequestSecurityTokenResponse rstr;

            return rst;

        }
        /*
               private static RequestSecurityTokenResponse RequsetOnBehalfOfToken()
               {

                   var factory = GetChannelFactory();

                   var rst = new RequestSecurityToken(WSTrustFeb2005Constants.RequestTypes.Issue)

                   {

                       AppliesTo = new EndpointAddress(appliesTo),

                       OnBehalfOf = new SecurityTokenElement(new UserNameSecurityToken(

                           subjectUserName, subjectPassword)),

                   };

                   RequestSecurityTokenResponse rstr;

                   var channel = factory.CreateChannel();



                   channel.Issue(rst, out rstr);



                   return rstr;

               }
               private static WSTrustChannelFactory GetChannelFactory()
               {

                   var binding = GetBinding();

                   var endpoint = new EndpointAddress(stsAddress);

                   var factory = new WSTrustChannelFactory(binding, endpoint)

                   {

                       TrustVersion = TrustVersion.WSTrustFeb2005

                   };



                   factory.Credentials.UserName.UserName = userName;

                   factory.Credentials.UserName.Password = password;



                   return factory;

               }

               private static Binding GetBinding()
               {

                   var binding = new CustomBinding();



                   binding.Elements.AddRange(new BindingElement[]

                    {

                        SecurityBindingElement

                            .CreateUserNameOverTransportBindingElement(),


                        new TextMessageEncodingBindingElement(MessageVersion

                            .Soap11WSAddressingAugust2004, Encoding.UTF8),

                        new HttpsTransportBindingElement(),

                    });



                   return binding;

               }
               */
    }
}