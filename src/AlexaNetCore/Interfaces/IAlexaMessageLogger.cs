using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaNetCore.Interfaces
{
    public interface IAlexaMessageLogger
    {

        void Debug(string messageTemplate);
       
        void Information(string messageTemplate);

        void Warning(string messageTemplate);

        void Error(string messageTemplate);
        
        void Error<T>(string messageTemplate, T propertyValue);

        void Error(Exception exception);

        void Error(Exception exception, string messageTemplate);

    }
}
