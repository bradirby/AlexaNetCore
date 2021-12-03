using System;
using AlexaNetCore;
using AlexaNetCoreSampleSkill.Intents;

namespace AlexaNetCoreSampleSkill
{
    public class SampleSkill : AlexaSkillBase
    {

        public SampleSkill()
        {
            //There is a default console logger built in.  It can be replaced with any logger that
            //implements IAlexaSkillMessageLogger.  
            MsgLogger.Debug("Sample skill is initializing");

            SetSkillVersion("0.1");

            //There are default intent handlers you can use for simple interactions, or implement your own
            RegisterIntentHandler(new DefaultLaunchIntentHandler("Hello, what can this SampleSkill do for you today?"));
            RegisterIntentHandler(new DefaultHelpIntentHandler("I can help you with that"));
            RegisterIntentHandler(new DefaultCancelIntentHandler("Goodbye"));

            //This will register default handlers for the remaining actions.  Previously defined handlers will not be overwritten
            RegisterDefaultIntentHandlers();

            //Then register your custom intent handlers
            RegisterIntentHandler(new SampleSkillIntentHandler(MsgLogger));
        }

        
    }
}
