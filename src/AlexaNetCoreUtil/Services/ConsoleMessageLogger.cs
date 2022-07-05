using System;
using System.Collections.Generic;
using System.Text;
using AlexaNetCore.Interfaces;
using Amazon.Lambda.Core;

namespace AlexaNetCore.Util
{
    public class ConsoleMessageLogger : IAlexaMessageLogger
    {
        internal ILambdaLogger lambdaLogger;

        public ConsoleMessageLogger()
        {
            lambdaLogger = null;
        }

        public ConsoleMessageLogger(ILambdaLogger log)
        {
            if (log!=null) lambdaLogger = log;
        }

        private string LoggerType { get; set; } = "[?] ";


        private string GetDateStamp(string logType)
        {
            return ($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logType}]");
        }

        public void Debug(string messageTemplate)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("DEBUG")} {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Information(string messageTemplate)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Warning(string messageTemplate)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Error(string messageTemplate)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }

        public void Error<T1>(string messageTemplate, T1 propertyValue)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValue);
            else lambdaLogger.Log($"{messageTemplate} {propertyValue}");
        }

        public void Error(Exception exception)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message);
            else lambdaLogger.Log($"{exception.Message}");
        }


        public void Error(Exception exception, string messageTemplate)
        {
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate);
            else lambdaLogger.Log($"{exception.Message} {messageTemplate} ");
        }


    }
}