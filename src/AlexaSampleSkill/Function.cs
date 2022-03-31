using AlexaNetCore;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SlotChecker
{
    public class SampleSkillLambdaFunction
    {
        public string BasicFunctionHandler(AlexaSkillRequestEnvelope input)
        {
            return  new SlotCheckerSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        public string BasicFunctionHandlerWithContext(AlexaSkillRequestEnvelope input, ILambdaContext context)
        {
            return  new SlotCheckerSkill(context.Logger).LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        public string BasicFunctionHandlerWithBuiltInLogger(AlexaSkillRequestEnvelope input)
        {
            var log = new ConsoleMessageLogger();
            return  new SlotCheckerSkill(log).LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }
     
    }

}


