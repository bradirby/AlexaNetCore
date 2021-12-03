using System.Diagnostics;
using System.Text.Json;
using AlexaNetCore;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlexaNetCoreSampleSkill
{
    public class SampleSkillLambdaFunction
    {
        
        public string ProductionFunctionHandler(AlexaSkillRequestEnvelope input)
        {
            return  new SampleSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        public string TestFunctionHandler(object input, ILambdaContext context)
        {
            var skill = new SampleSkill().LoadRequest(input.ToString()).ProcessRequest();
            skill.ValidateResponse();
            return skill.CreateAlexaResponse();
        }
     
    }
}
