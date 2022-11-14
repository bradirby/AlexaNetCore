using AlexaNetCore.Model;
using AlexaNetCore.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNetCore.Interfaces
{
    public abstract class  AlexaBaseRequestInterceptor
    {
        private AlexaRequestEnvelope ReqEnv;
        public int ExecutionOrder { get; set; }

        internal async Task ProcessAsync_Internal(AlexaRequestEnvelope reqEnv)
        {
            ReqEnv = reqEnv;
            await ProcessAsync(reqEnv);
        }

        public abstract Task ProcessAsync(IAlexaRequestEnvelope requestEnvelope);

        public void SetSessionValue(string key, string val)
        {
            ReqEnv.SetSessionAttribute(key, val);
        }
    }



    public abstract class AlexaBaseResponseInterceptor
    {
        public int ExecutionOrder { get; set; }

        internal async Task ProcessAsync_Internal(AlexaRequestEnvelope reqenv, AlexaResponseEnvelope respenv)
        {
            await ProcessAsync(reqenv, respenv);
        }

        public abstract Task ProcessAsync(IAlexaRequestEnvelope reqEnv, IAlexaResponseEnvelope respEnv);

    }
}
