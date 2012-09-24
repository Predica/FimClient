using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {

    // Manually added code for RmPerson
    partial class RmPerson {

        /// <summary>
        /// Gets a string containing a combination of display and account name, 
        /// to distinguish among multiple accounts with the same display name.
        /// </summary>
        public string DisplayInformation {
            get {
                // the default values should never be returned, using them only
                // to show more evidently that some error occurred (attributes 
                // not requested with the query or similar).
                string displayName = string.IsNullOrEmpty(DisplayName) ?
                    "<No Display Name>" :
                    DisplayName;
                string accountName = string.IsNullOrEmpty(AccountName) ?
                    "<No Account Name>" :
                    AccountName;
                return string.Format("{0} ({1})", displayName, accountName);
            }
        }

    }
}
