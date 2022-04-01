using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class LanguageInteractionModel
    {
        [JsonPropertyName("languageModel")]
        public IntentCollectionInteractionModel IntentCollectionIteractionModel { get; set; }

        public LanguageInteractionModel(AlexaLocale locale, string invocationName, List<AlexaIntentHandlerBase> intents, 
            List<CustomSlotTypeInteractionModel> SlotTypes = null)
        {
            IntentCollectionIteractionModel = new IntentCollectionInteractionModel(locale, invocationName, intents, SlotTypes);
        }
    }
}