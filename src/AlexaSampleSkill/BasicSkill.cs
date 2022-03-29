using AlexaNetCore;
using AlexaSampleSkill.Intents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AlexaSampleSkill
{
    public class BasicSkill: AlexaSkillBase
    {

        public BasicSkill() : base()
        {
            SetSkillVersion("0.1");
            InvocationName = "My Basic Skill";
            RegisterDefaultIntentHandlers();
            RegisterIntentHandler(new BasicIntent());
        }

        public BasicSkill(ILambdaLogger log) : base(log)
        {
            SetSkillVersion("0.1");
            InvocationName = "My Basic Skill";
            RegisterDefaultIntentHandlers();
            RegisterIntentHandler(new BasicIntent());
        }
        
        public BasicSkill(IAlexaNetCoreMessageLogger log) : base(log)
        {
            SetSkillVersion("0.1");
            InvocationName = "My Basic Skill";
            RegisterDefaultIntentHandlers();
            RegisterIntentHandler(new BasicIntent());
        }
    }
}
