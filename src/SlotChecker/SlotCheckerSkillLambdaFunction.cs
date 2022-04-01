using AlexaNetCore;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

//SlotChecker::SlotChecker.SlotCheckerSkillLambdaFunction::SlotCheckerFunction

namespace SlotChecker
{
    public class SlotCheckerSkillLambdaFunction
    {
        public string SlotCheckerFunction(AlexaSkillRequestEnvelope input)
        {
            return  new SlotCheckerSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

     
    }

}


