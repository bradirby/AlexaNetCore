using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class IntentCollectionIteractionModel
    {
        [JsonPropertyName("invocationName")]
        public string InvocationName { get; set; }


        [JsonPropertyName("intents")]
        public IntentInteractionModel[] IntentHandlerModels { get; set; }


        [JsonPropertyName("types")] 
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomSlotTypeInteractionModel[] CustomSlotTypes { get; set; } 



        public IntentCollectionIteractionModel(AlexaLocale locale , string invocationName, List<AlexaIntentHandlerBase> intents
            , List<CustomSlotTypeInteractionModel> slots = null)
        {
            if (string.IsNullOrEmpty(invocationName)) throw new ArgumentNullException();
            if (intents == null) throw new ArgumentNullException();
            if (!intents.Any()) throw new ArgumentNullException();

            InvocationName = invocationName;
            var intentModels = new List<IntentInteractionModel>();
            foreach (var intent in intents) intentModels.Add(intent.GetInteractionModel(locale));
            IntentHandlerModels = intentModels.ToArray();

            if (slots == null) CustomSlotTypes = null;
            else if (!slots.Any()) CustomSlotTypes = null;
            else CustomSlotTypes = slots.ToArray();
        }
    }

}
