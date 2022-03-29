using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SkillInteractionModel
    {
        [JsonPropertyName("interactionModel")]
        public LanguageInteractionModel LanguageModel { get; set; }

        public SkillInteractionModel(string invocationName, List<AlexaIntentHandlerBase> intents, List<CustomSlotTypeInteractionModel> slotTypes = null)
        {
            LanguageModel = new LanguageInteractionModel(invocationName, intents, slotTypes);
        }
    }
}