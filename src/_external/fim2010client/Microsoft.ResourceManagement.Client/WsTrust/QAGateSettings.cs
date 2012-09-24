using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class QAGateSettings
    {
        private String _encodedGateSettings;
        private int[] settingsArray
        {
            get
            {
                byte[] encodedGateSettingsByteArray = Convert.FromBase64String(_encodedGateSettings);
                String gateSettingsDecoded = System.Text.UnicodeEncoding.Unicode.GetString(encodedGateSettingsByteArray);
                string[] gateSettingStrings = gateSettingsDecoded.Split('\n');
                int[] gateSettings = new int[gateSettingStrings.Length];
                for (int c=0; c<gateSettingStrings.Length; c++)
                {
                    gateSettings[c] = Convert.ToInt16(gateSettingStrings[c]);
                }

                return gateSettings;
            }
        }
        public int QuestionsDisplayedDuringRegistration
        {
            get
            {
                return settingsArray[0];
            }
        }
        public int QuestionsRequiredForRegistration
        {
            get
            {
                return settingsArray[1];
            }
        }
        public int QuestionsPresentedToUser
        {
            get
            {
                return settingsArray[2];
            }
        }
        public int CorrectAnswersRequired
        {
            get
            {
                return settingsArray[3];
            }
        }
        public String encodedGateSettings
        {
            get
            {
                return _encodedGateSettings;
            }
            set
            {
                _encodedGateSettings = value;
            }
        }
    }
}
