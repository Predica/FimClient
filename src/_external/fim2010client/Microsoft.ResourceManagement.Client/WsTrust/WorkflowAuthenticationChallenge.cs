using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class WorkflowAuthenticationChallenge
    {
        private QAGateSettings _QAGateSettings;
        private QAGateData _QAGateData;
        private String _QAHashEncoded;

        [XmlElement()]
        public String settings
        {
            get
            {
                return _QAGateSettings.encodedGateSettings;
            }
            set
            {
                _QAGateSettings.encodedGateSettings = value;
            }
        }
        [XmlElement()]
        public String data
        {
            get
            {
                return _QAGateData.EncodedQAGateData;
            }
            set
            {
                _QAGateData.EncodedQAGateData = value;
            }
        }
        [XmlElement()]
        public string hash
        {
            get
            {
                return _QAHashEncoded;
            }
            set
            {
                _QAHashEncoded = value;
            }
        }
        [XmlElement()]
        public string Name;
        [XmlElement()]
        public string ActivityGuid;
        public string QAHash
        {
            get
            {
                return ChallengeResponseHelper.ConvertBase64StringToString(_QAHashEncoded);
            }
        }



        public String[] GateQuestions
        {
            get
            {
                return this._QAGateData.GateQuestions;
            }
        }

        public int QuestionsDisplayedDuringRegistration
        {
            get
            {
                return this._QAGateSettings.QuestionsDisplayedDuringRegistration;
            }
        }
        public int QuestionsRequiredForRegistration
        {
            get
            {
                return this._QAGateSettings.QuestionsRequiredForRegistration;
            }
        }
        public int QuestionsPresentedToUser
        {
            get
            {
                return this._QAGateSettings.QuestionsPresentedToUser;
            }
        }
        public int CorrectAnswersRequired
        {
            get
            {
                return this._QAGateSettings.CorrectAnswersRequired;
            }
        }


        public WorkflowAuthenticationChallenge()
        { 
        _QAGateSettings = new QAGateSettings();
        _QAGateData = new QAGateData();
        }
    }
    

}
