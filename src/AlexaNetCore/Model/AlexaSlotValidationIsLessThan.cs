using System;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Accept values that are less than a specified value. If the user's value is greater than
    /// or equal to the specified value, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsLessThan<T> : IAlexaSlotValidation
    {

        /// <summary>
        /// Prompt to use when the user supplied value does not pass the test
        /// </summary>
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; private set; }= "isLessThan";


        private T Item;


        /// <summary>
        /// Forces slot value to be smaller than the given value. If the value check fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">largest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsLessThan(T item, AlexaPrompt p)
        {
            Prompt = p;
            Item = item;
        }

        /// <summary>
        /// Forces slot value to be smaller than the given value. If the value check fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">largest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsLessThan(T item, string str)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(),str);
            Item = item;
        }

        /// <summary>
        /// Forces slot value to be smaller than the given value. If the value check fails,
        /// the prompt will be issued to the user to submit another value.
        /// </summary>
        /// <param name="item">largest valid value of the given type</param>
        /// <param name="str">Prompt to use when asking the user for another value </param>
        public AlexaSlotValidationIsLessThan(T item, AlexaMultiLanguageText prompt)
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
        public AlexaSlotValidationIsLessThan<T> AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }

    }
}