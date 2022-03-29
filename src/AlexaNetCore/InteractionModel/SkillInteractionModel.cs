using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SkillInteractionModel
    {
        [JsonPropertyName("invocationName")]
        public string InvocationName { get; set; }


        [JsonPropertyName("intents")]
        public IntentHandlerInteractionModel[] IntentHandlerModels { get; set; }


        public SkillInteractionModel(string invocationName, List<AlexaIntentHandlerBase> intents)
        {
            if (string.IsNullOrEmpty(invocationName)) throw new ArgumentNullException();
            if (intents == null) throw new ArgumentNullException();
            if (!intents.Any()) throw new ArgumentNullException();

            InvocationName = invocationName;
            var intentModels = new List<IntentHandlerInteractionModel>();
            foreach (var intent in intents)
            {
                intentModels.Add(intent.GetInteractionModel());
            }

            IntentHandlerModels = intentModels.ToArray();
        }
    }
}
