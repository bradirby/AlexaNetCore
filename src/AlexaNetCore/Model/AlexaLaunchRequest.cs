using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SkillForNet
{
    [DataContract]
    public class AlexaLaunchRequest
    {


        public string RequestType { get; set; }
        public string RequestID { get; set; }
    }
}