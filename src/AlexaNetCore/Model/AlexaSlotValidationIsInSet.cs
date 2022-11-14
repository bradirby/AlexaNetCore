using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Accept values that match a fixed set of values you specify.
    /// If the user provides a value that does not match any validationItems on this list, the value fails the validation.
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsInSet<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; set; }= "isInSet";

        private List<T> ValidationItems;

        /// <summary>
        /// Accept values that match a fixed set of values you specify.
        /// If the user provides a value that does not match any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        public AlexaSlotValidationIsInSet(IEnumerable<T> validationItems, AlexaPrompt invalidValuePrompt)
        {
            Prompt = invalidValuePrompt;
            ValidationItems = validationItems.ToList();
        }

        /// <summary>
        /// Accept values that match a fixed set of values you specify.
        /// If the user provides a value that does not match any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        public AlexaSlotValidationIsInSet(AlexaPrompt invalidValuePrompt)
        {
            Prompt = invalidValuePrompt;
            ValidationItems = new List<T>();
        }

        /// <summary>
        /// Accept values that match a fixed set of values you specify.
        /// If the user provides a value that does not match any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        public AlexaSlotValidationIsInSet(IEnumerable<T> validationItems, string invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = validationItems.ToList();
        }

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaSlotValidationIsInSet<T> AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }


        /// <summary>
        /// Accept values that match a fixed set of values you specify.
        /// If the user provides a value that does not match any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        public AlexaSlotValidationIsInSet(string invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = new List<T>();
        }

        /// <summary>
        /// Add a valid item to the set
        /// </summary>
        public AlexaSlotValidationIsInSet<T> AddSetItem(T validItem)
        {
            ValidationItems.Add(validItem);
            return this;
        }

        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;
            obj.values = ValidationItems.ToArray();

            return obj;

        }

    }
}