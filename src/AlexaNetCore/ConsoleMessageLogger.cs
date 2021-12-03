using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaSkillDotNet
{
      public class ConsoleMessageLogger : IAlexaSkillMessageLogger
    {
        private LogHistory History = new LogHistory();

        private string LoggerType { get; set; } = "[?] ";

        public List<string> GetLogHistory()
        {
            return History.GetLogHistory();
        }

        public void SetLoggerType<T>()
        {
            LoggerType = $"[{typeof(T)}] ";
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

        public void Debug<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Debug($"{messageTemplate} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("DEBUG")}  {LoggerType} {messageTemplate}", propertyValue);
        }

        public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Debug($"{messageTemplate} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("DEBUG")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1);
        }

        public void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Debug($"{messageTemplate} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("DEBUG")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1, propertyValue2);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            History?.Debug(messageTemplate);
            Console.WriteLine($"{GetDateStamp("DEBUG")}  {LoggerType} {messageTemplate}", propertyValues);
        }

        public void Debug(Exception exception, string messageTemplate)
        {
            History?.Debug($"{messageTemplate} {exception.Message}");
            Console.WriteLine($"{GetDateStamp("DEBUG")} " + LoggerType + exception.Message, messageTemplate);
        }

        public void Debug<T1>(Exception exception, string messageTemplate, T1 propertyValue)
        {
            History?.Debug($"{messageTemplate} {exception.Message} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("DEBUG")} " + LoggerType + exception.Message, messageTemplate, propertyValue);
        }

        public void Debug<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Debug($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("DEBUG")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Debug<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Debug($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("DEBUG")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            History?.Debug(messageTemplate);
            Console.WriteLine($"{GetDateStamp("DEBUG")} " + LoggerType + exception.Message, messageTemplate, propertyValues);
        }

        //**********************************************************************************************

        public void Information(string messageTemplate)
        {
            History?.Information(messageTemplate);
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}");
        }

        public void Information<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Information($"{messageTemplate} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}", propertyValue);
        }

        public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Information($"{messageTemplate} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}", propertyValue0, propertyValue1);
        }

        public void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Information($"{messageTemplate} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}", propertyValue0, propertyValue1, propertyValue2);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            History?.Information(messageTemplate);
            Console.WriteLine($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}", propertyValues);
        }

        public void Information(Exception exception, string messageTemplate)
        {
            History?.Information($"{messageTemplate} {exception.Message}");
            Console.WriteLine($"{GetDateStamp("INFO")}" + LoggerType + exception.Message, messageTemplate);
        }

        public void Information<T1>(Exception exception, string messageTemplate, T1 propertyValue)
        {
            History?.Information($"{messageTemplate} {exception.Message} {propertyValue} ");
            Console.WriteLine($"{GetDateStamp("INFO")}" + LoggerType + exception.Message, messageTemplate, propertyValue);
        }

        public void Information<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Information($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} ");
            Console.WriteLine($"{GetDateStamp("INFO")}" + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Information<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Information($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} {propertyValue2} ");
            Console.WriteLine($"{GetDateStamp("INFO")}" + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            History?.Information(messageTemplate);
            Console.WriteLine($"{GetDateStamp("INFO")}" + LoggerType + exception.Message, messageTemplate, propertyValues);
        }

        //****************************************************************************************

        public void Warning(string messageTemplate)
        {
            History?.Warning(messageTemplate);
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}");
        }

        public void Warning<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Warning($"{messageTemplate} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}", propertyValue);
        }

        public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Warning($"{messageTemplate} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1);
        }

        public void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Warning($"{messageTemplate} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1, propertyValue2);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            History?.Warning(messageTemplate);
            Console.WriteLine($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}", propertyValues);
        }

        public void Warning(Exception exception, string messageTemplate)
        {
            History?.Warning($"{messageTemplate} {exception.Message}");
            Console.WriteLine($"{GetDateStamp("WARN")} " + LoggerType + exception.Message, messageTemplate);
        }

        public void Warning<T1>(Exception exception, string messageTemplate, T1 propertyValue)
        {
            History?.Warning($"{messageTemplate} {exception.Message} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("WARN")} " + LoggerType + exception.Message, messageTemplate, propertyValue);
        }

        public void Warning<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Warning($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("WARN")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Warning<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Warning($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("WARN")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            History?.Warning(messageTemplate);
            Console.WriteLine($"{GetDateStamp("WARN")} " + LoggerType + exception.Message, messageTemplate, propertyValues);
        }

        //**********************************************************************************************************

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

        public void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Error($"{messageTemplate} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1);
        }

        public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Error($"{messageTemplate} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1, propertyValue2);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            History?.Error($"{messageTemplate} ");
            Console.WriteLine($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}", propertyValues);
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

        public void Error<T1>(Exception exception, string messageTemplate, T1 propertyValue)
        {
            History?.Error($"{messageTemplate} {exception.Message} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate, propertyValue);
        }

        public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Error($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Error<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Error($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            History?.Error($"{messageTemplate} {exception.Message} ");
            Console.WriteLine($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message, messageTemplate, propertyValues);
        }

        //*************************************************************************

        public void Fatal(string messageTemplate)
        {
            History?.Fatal($"{messageTemplate} ");
            Console.WriteLine($"{GetDateStamp("FATAL")}  {LoggerType} {messageTemplate}");
        }

        public void Fatal<T1>(string messageTemplate, T1 propertyValue)
        {
            History?.Fatal($"{messageTemplate} {propertyValue}");
            Console.WriteLine($"{GetDateStamp("FATAL")}  {LoggerType} {messageTemplate}", propertyValue);
        }

        public void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Fatal($"{messageTemplate} {propertyValue0} {propertyValue1}");
            Console.WriteLine($"{GetDateStamp("FATAL")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1);
        }

        public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Fatal($"{messageTemplate} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("FATAL")}  {LoggerType} {messageTemplate}", propertyValue0, propertyValue1, propertyValue2);
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            History?.Fatal($"{messageTemplate} ");
            Console.WriteLine($"{GetDateStamp("FATAL")}  {LoggerType} {messageTemplate}", propertyValues);
        }

        public void Fatal(Exception exception, string messageTemplate)
        {
            History?.Error($"{messageTemplate} {exception.Message} ");
            Console.WriteLine($"{GetDateStamp("FATAL")} " + LoggerType + exception.Message, messageTemplate);
        }

        public void Fatal<T1>(Exception exception, string messageTemplate, T1 propertyValue)
        {
            History?.Fatal($"{messageTemplate} {exception.Message} {propertyValue} ");
            Console.WriteLine($"{GetDateStamp("FATAL")} " + LoggerType + exception.Message, messageTemplate, propertyValue);
        }

        public void Fatal<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            History?.Fatal($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} ");
            Console.WriteLine($"{GetDateStamp("FATAL")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Fatal<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            History?.Fatal($"{messageTemplate} {exception.Message} {propertyValue0} {propertyValue1} {propertyValue2}");
            Console.WriteLine($"{GetDateStamp("FATAL")} " + LoggerType + exception.Message, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            History?.Fatal($"{messageTemplate} {exception.Message} ");
            Console.WriteLine($"{GetDateStamp("FATAL")} " + LoggerType + exception.Message, messageTemplate, propertyValues);
        }

        public void WriteOutLogHistory()
        {
            History.WriteOutLogHistory(this);
        }

        public int MaxHistoryToKeep
        {
            get => History.MaxHistoryToKeep;
            set => History.MaxHistoryToKeep = value;
        }
    }
}
