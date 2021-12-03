using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaNetCore
{
      public class ConsoleMessageLogger : IAlexaNetCoreMessageLogger
    {
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
            Console.WriteLine($"{GetDateStamp("DEBUG")} {LoggerType} {messageTemplate}");
        }


        public void Information(string messageTemplate)
        {
            History?.Information(messageTemplate);
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}");
        }


        public void Warning(string messageTemplate)
        {
            History?.Warning(messageTemplate);
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}");
        }


        public void Error(string messageTemplate)
        {
            History?.Error(messageTemplate);
            Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}");
        }

        public void Error<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Error($"{messageTemplate} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValue);
        }

        public void Error(Exception exception)
        {
            History?.Error(exception.Message);
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message);
        }


        public void Error(Exception exception, string messageTemplate)
        {
            History?.Error($"{messageTemplate} {exception.Message} ");
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate);
        }


    }
}
