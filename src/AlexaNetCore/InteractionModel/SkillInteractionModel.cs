using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SkillInteractionModel
    {
        [JsonPropertyName("interactionModel")]
        public LanguageInteractionModel LanguageModel { get; set; }

        public SkillInteractionModel(AlexaLocale locale, string invocationName, List<AlexaIntentHandlerBase> intents, 
            List<CustomSlotTypeInteractionModel> slotTypes)
        {
            LanguageModel = new LanguageInteractionModel( locale, invocationName, intents, slotTypes);
        }
    }
}