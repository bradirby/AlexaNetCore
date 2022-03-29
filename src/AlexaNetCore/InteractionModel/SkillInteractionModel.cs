﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SkillInteractionModel
    {
        [JsonPropertyName("interactionModel")]
        public LanguageInteractionModel LanguageModel { get; set; }

        public SkillInteractionModel(string invocationName, List<AlexaIntentHandlerBase> intents)
        {
            LanguageModel = new LanguageInteractionModel(invocationName, intents);
        }
    }
}