using System;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Accept values that are greater than a specified value. If the user's value is
    /// less than or equal to the criteria, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsGreaterThan<T> : IAlexaSlotValidation
    {

        /// <summary>
        /// Prompt to use when the user supplied value does not pass the test
        /// </summary>
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; private set; }= "isGreaterThan";

        /// <summary>
        /// Smallest value allowed, inclusive
        /// </summary>
        private T Item;

        /// <summary>
        /// Forces slot value to be larger than or equal to the given value. If the value fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">Smallest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsGreaterThan(T item, AlexaPrompt p)
        {
            Prompt = p;
            Item = item;
        }

        /// <summary>
        /// Forces slot value to be larger than or equal to the given value. If the value fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">Smallest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsGreaterThan(T item, string str)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), str);
            Item = item;
        }

        /// <summary>
        /// Forces slot value to be larger than or equal to the given value. If the value fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">Smallest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsGreaterThan(T item, AlexaMultiLanguageText prompt)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), prompt);
            Item = item;
        }

        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;
            obj.value = Item;

            return obj;

        }

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaSlotValidationIsGreaterThan<T> AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }



    }
}