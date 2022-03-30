using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class LanguageInteractionModel
    {
        [JsonPropertyName("languageModel")]
        public IntentCollectionIteractionModel IntentCollectionIteractionModel { get; set; }

        public LanguageInteractionModel(string invocationName, List<AlexaIntentHandlerBase> intents, 
            List<CustomSlotTypeInteractionModel> SlotTypes = null, AlexaLocale locale = null)
        {
            IntentCollectionIteractionModel = new IntentCollectionIteractionModel(invocationName, intents, SlotTypes, locale);
        }
    }
}