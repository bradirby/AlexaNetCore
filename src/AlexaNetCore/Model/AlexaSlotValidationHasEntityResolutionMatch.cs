using System;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Accept values that are defined in the list of custom slot type values and synonyms.
    /// If the user provides a value that does not match any of these defined values, the
    /// value fails the validation and Alexa can use your prompts to ask the user for a new
    /// value. This is equivalent to checking the entity resolution status code for the Slot
    /// object (resolutions.resolutionsPerAuthority[].status.code) for the slot and only
    /// accepting values where the code is ER_SUCCESS_MATCH.
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationHasEntityResolutionMatch : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }
        public string ValidationType { get; set; }= "hasEntityResolutionMatch";


        /// <summary>
        /// Ensures the users response was one of the valid values provided.
        /// If not, the prompt is given to the user
        /// </summary>
        /// <param name="p">User prompt when the value does not validate</param>
        public AlexaSlotValidationHasEntityResolutionMatch(AlexaPrompt p)
        {
            Prompt = p;
        }

        /// <summary>
        /// Ensures the users response was one of the valid values provided.
        /// If not, the prompt is given to the user
        /// </summary>
        /// <param name="p">User prompt when the value does not validate</param>
        public AlexaSlotValidationHasEntityResolutionMatch(string p)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), p);
        }

        /// <summary>
        /// Ensures the users response was one of the valid values provided.
        /// If not, the prompt is given to the user
        /// </summary>
        /// <param name="p">User prompt when the value does not validate</param>
        public AlexaSlotValidationHasEntityResolutionMatch(AlexaMultiLanguageText p)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), p);
        }

        
        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;

            return obj;

        }

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaSlotValidationHasEntityResolutionMatch AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }



    }
}