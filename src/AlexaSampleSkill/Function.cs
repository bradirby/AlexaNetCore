using AlexaNetCore;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlexaSampleSkill
{
    public class SampleSkillLambdaFunction
    {
        public string BasicFunctionHandler(AlexaSkillRequestEnvelope input)
        {
            return  new BasicSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        public string BasicFunctionHandlerWithContext(AlexaSkillRequestEnvelope input, ILambdaContext context)
        {
            return  new BasicSkill(context.Logger).LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        public string BasicFunctionHandlerWithBuiltInLogger(AlexaSkillRequestEnvelope input)
        {
            var log = new ConsoleMessageLogger();
            return  new BasicSkill(log).LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }
     
    }

}


