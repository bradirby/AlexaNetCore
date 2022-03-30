﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class LanguageInteractionModel
    {
        [JsonPropertyName("languageModel")]
        public IntentCollectionIteractionModel IntentCollectionIteractionModel { get; set; }

        public LanguageInteractionModel(AlexaLocale locale, string invocationName, List<AlexaIntentHandlerBase> intents, 
            List<CustomSlotTypeInteractionModel> SlotTypes = null)
        {
            IntentCollectionIteractionModel = new IntentCollectionIteractionModel(locale, invocationName, intents, SlotTypes);
        }
    }
}