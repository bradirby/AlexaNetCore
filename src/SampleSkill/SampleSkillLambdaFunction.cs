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
        /// <summary>
        /// This is all that is necessary for a fully functional skill
        /// </summary>
        public string ProductionFunctionHandler(AlexaSkillRequestEnvelope input)
        {
            return  new SampleSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        /// <summary>
        /// You can add error logging and other data checks throughout the pipeline
        /// for easy debugging
        /// </summary>
        public string TestFunctionHandler(object input, ILambdaContext context)
        {
            var skill = new SampleSkill().LoadRequest(input.ToString()).ProcessRequest();
            skill.ValidateResponse();
            return skill.CreateAlexaResponse();
        }
     
    }
}
