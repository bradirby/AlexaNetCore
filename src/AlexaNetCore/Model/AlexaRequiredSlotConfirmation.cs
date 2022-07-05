using System;
using System.Collections.Generic;

namespace AlexaNetCore.Model
{
    public class AlexaRequiredSlotConfirmation
    {
        public AlexaPrompt ConfirmationPrompt { get; private set; }

        public AlexaRequiredSlotConfirmation SetConfirmationPrompt(AlexaPrompt prompt)
        {
            ConfirmationPrompt = prompt;
            return this;
        }
        /// <summary>
        /// The slot confirmation should be phrased as a Yes/No question
        /// </summary>
        public AlexaRequiredSlotConfirmation AddConfirmationPromptVariation(string promptTxt)
        {
            if (ConfirmationPrompt == null) ConfirmationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else ConfirmationPrompt.AddVariation(promptTxt);
            return this;
        }

        /// <summary>
        /// The slot confirmation should be phrased as a Yes/No question
        /// </summary>
        public AlexaRequiredSlotConfirmation AddConfirmationPromptVariation(List<string> promptTxt)
        {
            foreach (var txt in promptTxt)
            {
                AddConfirmationPromptVariation(txt);
            }
            return this;
        }

        
        /// <summary>
        /// The slot confirmation should be phrased as a Yes/No question
        /// </summary>
        public AlexaRequiredSlotConfirmation AddConfirmationPromptVariation(AlexaMultiLanguageText promptTxt)
        {
            if (ConfirmationPrompt == null) ConfirmationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else ConfirmationPrompt.AddVariation(promptTxt);
            return this;
        }

        

        /// <summary>
        /// The slot confirmation should be phrased as a Yes/No question
        /// </summary>
        public AlexaRequiredSlotConfirmation AddConfirmationPromptVariation(List<AlexaMultiLanguageText> promptTxt)
        {
            foreach (var p in promptTxt)
            {
                AddConfirmationPromptVariation(p);
            }
            return this;
        }
    }
}