using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using AlexaNetCore.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNetCore.Util.Interceptors
{
    /// <summary>
    /// This interceptor will change the language of the incoming request to
    /// the value given in order to simulate requests from different locales
    /// </summary>
    public class SetRequestLanguageDebugInterceptor: IAlexaRequestInterceptor
    {
        private AlexaLocale NewLocale;

        public SetRequestLanguageDebugInterceptor(AlexaLocale newLocale)
        {
            NewLocale = newLocale;
        }

        public Task<AlexaRequestEnvelope> ProcessAsync(AlexaRequestEnvelope reqEnv)
        {
            reqEnv.Request.LocaleString = NewLocale.LocaleString;
            return Task.FromResult(reqEnv);
        }

    }
}
