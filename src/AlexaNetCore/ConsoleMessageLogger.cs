using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Lambda.Core;

namespace AlexaNetCore
{
    public class ConsoleMessageLogger : IAlexaNetCoreMessageLogger
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

        private LogHistory History = new LogHistory();

        private string LoggerType { get; set; } = "[?] ";

        public List<string> GetLogHistory()
        {
            return History.GetLogHistory();
        }


        private string GetDateStamp(string logType)
        {
            return ($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logType}]");
        }

        public void Debug(string messageTemplate)
        {
            History?.Debug(messageTemplate);
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("DEBUG")} {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Information(string messageTemplate)
        {
            History?.Information(messageTemplate);
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Warning(string messageTemplate)
        {
            History?.Warning(messageTemplate);
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }


        public void Error(string messageTemplate)
        {
            History?.Error(messageTemplate);
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}");
            else lambdaLogger.Log(messageTemplate);
        }

        public void Error<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Error($"{messageTemplate} {propertyValue}");
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValue);
            else lambdaLogger.Log($"{messageTemplate} {propertyValue}");
        }

        public void Error(Exception exception)
        {
            History?.Error(exception.Message);
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message);
            else lambdaLogger.Log($"{exception.Message}");
        }


        public void Error(Exception exception, string messageTemplate)
        {
            History?.Error($"{messageTemplate} {exception.Message} ");
            if (lambdaLogger == null) Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate);
            else lambdaLogger.Log($"{exception.Message} {messageTemplate} ");
        }


    }
}