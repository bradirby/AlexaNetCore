using System;
using System.Collections.Generic;
using System.Text;
using AlexaNetCore.Interfaces;
using Amazon.Lambda.Core;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Util
{
    public class LambdaLoggerWrapper: ILogger
    {

        private string LoggerType { get; set; } = "[?] ";


        private string GetDateStamp(string logType)
        {
            return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logType}]";
        }

        public void LogDebug(string messageTemplate)
        {
            LambdaLogger.Log($"{GetDateStamp("DEBUG")} {LoggerType} {messageTemplate}");
        }


        public void LogInformation(string messageTemplate)
        {
            LambdaLogger.Log($"{GetDateStamp("INFO")} {LoggerType} {messageTemplate}");
        }


        public void LogWarning(string messageTemplate)
        {
            LambdaLogger.Log($"{GetDateStamp("WARN")}  {LoggerType} {messageTemplate}");
        }


        public void LogError(string messageTemplate)
        {
            LambdaLogger.Log($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}");
        }

        public void LogError<T1>(string messageTemplate, T1 propertyValue)
        {
            LambdaLogger.Log($"{GetDateStamp("ERROR")}  {LoggerType} {messageTemplate}");
        }

        public void LogError(Exception exception)
        {
            LambdaLogger.Log($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message);
        }


        public void LogError(Exception exception, string messageTemplate)
        {
            LambdaLogger.Log($"{GetDateStamp("ERROR")} " + LoggerType + exception.Message);
        }


        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return true;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }
    }
}