using System;
using System.Collections.Generic;
using AlexaSkillDotNet;

namespace AlexaSkillDotNet.Tests
{
    public class FakeAlexaSkillMessageLogger : IAlexaSkillMessageLogger
    {
        public string SourceName { get; set; }

        public FakeAlexaSkillMessageLogger(string srcName)
        {
            SourceName = srcName;
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }

        public void Debug(string msg, params object[] parms)
        {
            Messages.Add("Debug:" + msg);
        }

        public void Info(string msg, params object[] parms)
        {
            Messages.Add("Info:" + msg);
        }

        public void Warning(string msg, params object[] parms)
        {
            Messages.Add("Warn:" + msg);
        }

        public void CloseLog()
        {
            Messages.Add("CloseLog:");
        }

        public void Error(string msg, params object[] parms)
        {
            Messages.Add("Err:" + msg);
        }


        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Debug(AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, AlexaRequestEnvelope requestEnvelope, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, AlexaRequestEnvelope requestEnvelope, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, AlexaRequestEnvelope requestEnvelope, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, AlexaRequestEnvelope requestEnvelope, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exc)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exc, AlexaRequestEnvelope requestEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exc, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exc, AlexaRequestEnvelope requestEnvelope, AlexaResponseEnvelope responseEnvelope)
        {
            throw new NotImplementedException();
        }
    }
}
