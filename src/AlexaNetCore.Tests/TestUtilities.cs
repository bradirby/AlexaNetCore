using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Model;

namespace AlexaNetCore.Tests
{
    public static class TestUtilities
    {


        public static AlexaSkillBase RegisterDefaultTestHandlers(this AlexaSkillBase skill,AlexaMultiLanguageText txt)
        {
            skill.RegisterIntentHandler(new DefaultCancelIntentHandler(txt));
            skill.RegisterIntentHandler(new DefaultHelpIntentHandler(txt,null));
            skill.RegisterIntentHandler(new DefaultFallbackIntentHandler(txt));
            skill.RegisterIntentHandler(new DefaultLaunchIntentHandler(txt,null));
            skill.RegisterIntentHandler(new DefaultSessionEndRequest(txt));
            skill.RegisterIntentHandler(new DefaultStartOverIntentHandler(txt));
            skill.RegisterIntentHandler(new DefaultStopIntentHandler(txt));

            return skill;
        }

    }
}
