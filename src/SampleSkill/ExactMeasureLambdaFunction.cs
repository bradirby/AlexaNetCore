using System.Diagnostics;
using System.Text.Json;
using AlexaSkillDotNet;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ExactMeasureSkill
{
    public class ExactMeasureLambdaFunction
    {
        
        public string ProductionFunctionHandler(AlexaSkillRequestEnvelope input, ILambdaContext context)
        {
            var skill = new ExactMeasureAlexaSkill().LoadRequest(input).ProcessRequest();
            if (skill.IsRepromptSet) skill.SetRepromptSpeach("Is there anything else I can do?");
            return skill.CreateAlexaResponse();
        }

        public string TestFunctionHandler(object input, ILambdaContext context)
        {
            var skill = new ExactMeasureAlexaSkill().LoadRequest(input.ToString()).ProcessRequest();
            if (skill.IsRepromptSet) skill.SetRepromptSpeach("Hey Ditzo, did you need something?");
            skill.ValidateResponse();
            return skill.CreateAlexaResponse();
        }
     
    }
}
