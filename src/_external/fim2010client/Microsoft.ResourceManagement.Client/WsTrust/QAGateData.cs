using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class QAGateData
    {
        private String _encodedQAGateData;
        public String EncodedQAGateData
        {
            get
            {
                return _encodedQAGateData;
            }
            set
            {
                _encodedQAGateData = value;
            }
        }
        public String[] GateQuestions
        {
            get
            {
                byte[] encodedGateSettingsByteArray = Convert.FromBase64String(_encodedQAGateData);
                String gateSettings = System.Text.UnicodeEncoding.Unicode.GetString(encodedGateSettingsByteArray);
                String[] gateQuestionsWithNumbers = gateSettings.Split('\n');
                String[] gateQuestions = new String[gateQuestionsWithNumbers.Length / 2];
                int gateSettingsCounter = 0;
                for (int c = 1; c < gateQuestionsWithNumbers.Length; c+=2)
                {
                    gateQuestions[gateSettingsCounter] = gateQuestionsWithNumbers[c];
                    gateSettingsCounter++;
                }
                return gateQuestions;
            }
        }

    }
}
