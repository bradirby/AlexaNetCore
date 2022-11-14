using System;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Accept date or time values that fall within a specified time span. If the user's value
    /// is before or after the specified time span, the value fails validation.
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsInDuration<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; set; }= "isInDuration";

        private T Start;

        private T End;

        public AlexaSlotValidationIsInDuration(T start, T end , AlexaPrompt p)
        {
            Prompt = p;
            Start = start;
            End = end;
        }

        public AlexaSlotValidationIsInDuration(T start, T end, string p)
        {
            Prompt = new AlexaPrompt( Guid.NewGuid().ToString(),p);
            Start = start;
            End = end;
        }

        public AlexaSlotValidationIsInDuration(T start, T end, AlexaMultiLanguageText p)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), p);
            Start = start;
            End = end;
        }

        
        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;
            obj.start = Start;
            obj.end = End;

            return obj;

        }

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaSlotValidationIsInDuration<T> AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }

    }
}