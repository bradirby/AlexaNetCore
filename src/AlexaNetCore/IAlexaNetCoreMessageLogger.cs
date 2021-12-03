using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaNetCore
{
    public interface IAlexaNetCoreMessageLogger
    {
        /// <summary>
        /// Returns a list of recent messages.  Useful in tests to see if any warnings or errors occurred
        /// </summary>
        /// <returns></returns>
        List<string> GetLogHistory();

        void Debug(string messageTemplate);
       
        void Information(string messageTemplate);

        void Warning(string messageTemplate);

        void Error(string messageTemplate);
        
        void Error<T>(string messageTemplate, T propertyValue);

        void Error(Exception exception);

        void Error(Exception exception, string messageTemplate);

    }
}
