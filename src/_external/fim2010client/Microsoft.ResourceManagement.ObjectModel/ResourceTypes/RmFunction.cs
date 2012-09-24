using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Function resource.
    /// Automatically generated on 06/30/2010 10:06:27
    /// </summary>
    [Serializable]
    public partial class RmFunction : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"Function`";

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
        public RmFunction()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmFunction(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Assembly
        /// The library in which to find functions.
        /// </summary>
        public string Assembly {
            get { return GetString(AttributeNames.Assembly); }
            set { base[AttributeNames.Assembly].Value = value; }
        }

        /// <summary>
        /// Function Name
        /// The name of the function.
        /// </summary>
        public string FunctionName {
            get { return GetString(AttributeNames.FunctionName); }
            set { base[AttributeNames.FunctionName].Value = value; }
        }

        /// <summary>
        /// Namespace
        /// The namespace where the function resides.
        /// </summary>
        public string Namespace {
            get { return GetString(AttributeNames.Namespace); }
            set { base[AttributeNames.Namespace].Value = value; }
        }

        /// <summary>
        /// Parameters List
        /// Contains the list of parameters a function takes as input.
        /// </summary>
        public string FunctionParameters {
            get { return GetString(AttributeNames.FunctionParameters); }
            set { base[AttributeNames.FunctionParameters].Value = value; }
        }

        /// <summary>
        /// Return Type
        /// The type of the value returned by a function.
        /// </summary>
        public string ReturnType {
            get { return GetString(AttributeNames.ReturnType); }
            set { base[AttributeNames.ReturnType].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Assembly, false);
            EnsureAttributeExists(AttributeNames.FunctionName, false);
            EnsureAttributeExists(AttributeNames.Namespace, false);
            EnsureAttributeExists(AttributeNames.FunctionParameters, false);
            EnsureAttributeExists(AttributeNames.ReturnType, false);
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
        /// Names of Function specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Assembly
            /// The library in which to find functions.
            /// </summary>
            public static RmAttributeName Assembly = new RmAttributeName(@"Assembly");
            /// <summary>
            /// Function Name
            /// The name of the function.
            /// </summary>
            public static RmAttributeName FunctionName = new RmAttributeName(@"FunctionName");
            /// <summary>
            /// Namespace
            /// The namespace where the function resides.
            /// </summary>
            public static RmAttributeName Namespace = new RmAttributeName(@"Namespace");
            /// <summary>
            /// Parameters List
            /// Contains the list of parameters a function takes as input.
            /// </summary>
            public static RmAttributeName FunctionParameters = new RmAttributeName(@"FunctionParameters");
            /// <summary>
            /// Return Type
            /// The type of the value returned by a function.
            /// </summary>
            public static RmAttributeName ReturnType = new RmAttributeName(@"ReturnType");
        }
        
        #endregion
        
    }
}
        
