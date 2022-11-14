﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.RequestModel;

namespace AlexaNetCore.Util.Interceptors
{
    public class AddSlotValueDebugInterceptor : AlexaBaseRequestInterceptor
    {
        private string slotName;
        private string slotValue;

        public AddSlotValueDebugInterceptor(string sName, string sValue)
        {
            slotName = sName;
            slotValue = sValue;
        }

        public override Task ProcessAsync(IAlexaRequestEnvelope reqEnv)
        {
            reqEnv.SetSlotValue(slotName,slotValue);
            return Task.CompletedTask;
            

        }
    }
}
