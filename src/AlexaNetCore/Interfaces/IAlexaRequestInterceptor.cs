using AlexaNetCore.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNetCore.Interfaces
{
    public interface IAlexaRequestInterceptor
    {
        Task<AlexaRequestEnvelope> ProcessAsync(AlexaRequestEnvelope reqEnv);
    }
}
