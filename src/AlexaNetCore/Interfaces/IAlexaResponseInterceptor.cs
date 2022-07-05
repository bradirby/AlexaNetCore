using AlexaNetCore.Model;
using AlexaNetCore.RequestModel;
using System.Threading.Tasks;

namespace AlexaNetCore.Interfaces
{
    public interface IAlexaResponseInterceptor
    {
        Task<AlexaResponseEnvelope> ProcessAsync(AlexaRequestEnvelope reqEnv, AlexaResponseEnvelope respEnv);
    }
}