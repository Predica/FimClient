using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// EmailTemplate resource.
    /// Automatically generated on 06/30/2010 10:06:11
    /// </summary>
    [Serializable]
    public partial class RmEmailTemplate : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"EmailTemplate`";

        /// <summary>
        /// Gets the FIM name of the wrapped resource type.
        /// </summary>
        /// <returns>The FIM name of the wrapped resource type.</returns>
        public override string GetResourceType() {
            return ResourceType;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmEmailTemplate()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmEmailTemplate(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Body
        /// This is the body of the e-mail. E-mails are sent as HTML and can include HTML tags if needed, e.g. br will provide a line break.
        /// </summary>
        public string EmailBody {
            get { return GetString(AttributeNames.EmailBody); }
            set { base[AttributeNames.EmailBody].Value = value; }
        }

        /// <summary>
        /// Subject
        /// This is the subject of the e-mail.
        /// </summary>
        public string EmailSubject {
            get { return GetString(AttributeNames.EmailSubject); }
            set { base[AttributeNames.EmailSubject].Value = value; }
        }

        /// <summary>
        /// Template Type
        /// This is the context this e-mail can be used in the workflow activities.
        /// </summary>
        public string EmailTemplateType {
            get { return GetString(AttributeNames.EmailTemplateType); }
            set { base[AttributeNames.EmailTemplateType].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.EmailBody, false);
            EnsureAttributeExists(AttributeNames.EmailSubject, false);
            EnsureAttributeExists(AttributeNames.EmailTemplateType, false);
            // ensure custom (non FIM-standard) attributes exist.
            EnsureCustomAttributesExist();
        }
        
        /// <summary>
        /// Implement this method to ensure that custom attributes, i.e.
        /// attributes not defined in the default FIM schema, exist.
        /// </summary>
        partial void EnsureCustomAttributesExist();
        
        #endregion
        
        #region AttributeNames
        
        /// <summary>
        /// Names of EmailTemplate specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Body
            /// This is the body of the e-mail. E-mails are sent as HTML and can include HTML tags if needed, e.g. br will provide a line break.
            /// </summary>
            public static RmAttributeName EmailBody = new RmAttributeName(@"EmailBody");
            /// <summary>
            /// Subject
            /// This is the subject of the e-mail.
            /// </summary>
            public static RmAttributeName EmailSubject = new RmAttributeName(@"EmailSubject");
            /// <summary>
            /// Template Type
            /// This is the context this e-mail can be used in the workflow activities.
            /// </summary>
            public static RmAttributeName EmailTemplateType = new RmAttributeName(@"EmailTemplateType");
        }
        
        #endregion
        
    }
}
        
