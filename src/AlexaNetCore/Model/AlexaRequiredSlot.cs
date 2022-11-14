using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaNetCore.Model
{
    public class AlexaRequiredSlot
    {

        /// <summary>
        /// Makes a slot required and adds a prompt for the user when they do not provide the value
        /// </summary>
        public AlexaRequiredSlot(string elicitationPrompt)
        {
            ElicitationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), elicitationPrompt);
        }

        /// <summary>
        /// Makes a slot required and adds a prompt for the user when they do not provide the value
        /// </summary>
        public AlexaRequiredSlot(AlexaPrompt elicitationPrompt)
        {
            ElicitationPrompt = elicitationPrompt;
        }

        /// <summary>
        /// Makes a slot required and adds a prompt for the user when they do not provide the value
        /// </summary>
        public AlexaRequiredSlot(AlexaMultiLanguageText elicitationPrompt)
        {
            ElicitationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), elicitationPrompt);
        }


        public AlexaRequiredSlotConfirmation Confirmation { get; set; }

        public bool ConfirmationRequired => Confirmation != null;

        public AlexaPrompt ElicitationPrompt { get; set; }

        public bool ElicitationRequired => ElicitationPrompt != null;


        /// <summary>
        /// Only valid for required slots.  These are the utterances the customer can say in response to the
        /// prompt given if the value is missing.  These utterances should include the slot validation
        /// </summary>
        public List<string> UserUtterances { get; set; } = new List<string>();



        public AlexaRequiredSlot RequireSlotConfirmation(AlexaRequiredSlotConfirmation def)
        {
            Confirmation = def;
            return this;
        }


        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaRequiredSlot AddMissingValuePromptVariation(string promptTxt)
        {
            if (ElicitationPrompt == null) ElicitationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else ElicitationPrompt.AddVariation(promptTxt);
            return this;
        }

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaRequiredSlot AddMissingValuePromptVariation(List<string> promptTxt)
        {
            foreach (string promptTxtItem in promptTxt)
            {
                AddMissingValuePromptVariation(promptTxtItem);
            }
            return this;
        }

        public AlexaRequiredSlot AddMissingValuePromptVariation(AlexaMultiLanguageText promptTxt)
        {
            if (ElicitationPrompt == null) ElicitationPrompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else ElicitationPrompt.AddVariation(promptTxt);
            return this;
        }

        public AlexaRequiredSlot AddMissingValuePromptVariation(List<AlexaMultiLanguageText> promptTxt)
        {
            foreach (var p in promptTxt)
            {
                AddMissingValuePromptVariation(p);
            }
            return this;
        }


        /// <summary>
        /// Add one utterance the user could say in order to satisfy this slot.  The utterance should contain the slot name
        /// </summary>
        /// <param name="promptTxt">What the user might say</param>
        public AlexaRequiredSlot AddUserUtterance(string promptTxt)
        {
            UserUtterances.Add(promptTxt);
            return this;
        }

        /// <summary>
        /// Add one utterance the user could say in order to satisfy this slot.  The utterance should contain the slot name
        /// </summary>
        /// <param name="promptTxt">What the user might say</param>
        public AlexaRequiredSlot AddUserUtterance(List<string> promptTxt)
        {
            foreach (var txt in promptTxt) UserUtterances.Add(txt);
            return this;
        }

        /// <summary>
        /// Prompt to use when the user has not specified a value for this slot
        /// </summary>
        /// <param name="prompt">What to say to the user</param>
        public AlexaRequiredSlot SetMissingValuePrompt(AlexaPrompt prompt)
        {
            ElicitationPrompt = prompt;
            return this;
        }


      
        internal IEnumerable<AlexaPrompt> GetAllPrompts()
        {
            var lst = new List<AlexaPrompt>();

            if (ElicitationPrompt != null) lst.Add(ElicitationPrompt);

            if (ConfirmationRequired && Confirmation.ConfirmationPrompt != null) lst.Add(Confirmation.ConfirmationPrompt);

            return lst;
        }

    }
}