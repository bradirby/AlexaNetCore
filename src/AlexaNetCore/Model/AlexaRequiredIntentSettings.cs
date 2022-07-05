using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlexaNetCore.Model
{
    public class AlexaRequiredIntentSettings
    {
        public AlexaPrompt Prompt { get; set; }

        public AlexaRequiredIntentSettings AddPromptVariation(string variation)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), variation);
            else Prompt.AddVariation(variation);
            return this;
        }

        public AlexaRequiredIntentSettings AddPromptVariation(AlexaMultiLanguageText variation)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), variation);
            else Prompt.AddVariation(variation);
            return this;
        }

        public AlexaRequiredIntentSettings AddPromptVariation(IEnumerable<string> variationLst)
        {
            foreach (var str in variationLst) AddPromptVariation(str);
            return this;
        }

        public AlexaRequiredIntentSettings AddPromptVariation(IEnumerable<AlexaMultiLanguageText> variationLst)
        {
            foreach (var str in variationLst) AddPromptVariation(str);
            return this;
        }

    }
}