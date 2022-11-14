using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// Reject values that match a fixed set of values you specify.
    /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsNotInSet<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; set; } = "isNotInSet";

         private IList<T> ValidationItems;

        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="validationItems">List of items that are invalid</param>
        /// <param name="invalidValuePrompt">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(IList<T> validationItems, AlexaPrompt invalidValuePrompt)
        {
            Prompt = invalidValuePrompt;
            ValidationItems = validationItems;
        }

        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="invalidValuePrompt">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(AlexaPrompt invalidValuePrompt)
        {
            Prompt = invalidValuePrompt;
            ValidationItems = new List<T>();
        }

        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="validationItems">List of items that are invalid</param>
        /// <param name="invalidValuePromptText">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(IList<T> validationItems, string invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = validationItems;
        }
        
        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="invalidValuePromptText">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(string invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = new List<T>();
        }

        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="validationItems">List of items that are invalid</param>
        /// <param name="invalidValuePromptText">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(IList<T> validationItems, AlexaMultiLanguageText invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = validationItems;
        }

        /// <summary>
        /// Reject values that match a fixed set of values you specify.
        /// If the user provides a value that matches any validationItems on this list, the value fails the validation.
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
        /// </summary>
        /// <param name="invalidValuePromptText">Prompt to say to the user when their given value is invalid</param>
        public AlexaSlotValidationIsNotInSet(AlexaMultiLanguageText invalidValuePromptText)
        {
            Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), invalidValuePromptText);
            ValidationItems = new List<T>();
        }

        /// <summary>
        /// Add a new item to the list of invalid items
        /// </summary>
        public AlexaSlotValidationIsNotInSet<T> AddSetItem(T item)
        {
            ValidationItems.Add(item);
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

        /// <summary>
        /// Add a prompt for the user if the slot has no value
        /// </summary>
        /// <param name="promptTxt">Prompt to give the user</param>
        public AlexaSlotValidationIsNotInSet<T> AddInvalidValuePromptVariation(string promptTxt)
        {
            if (Prompt == null) Prompt = new AlexaPrompt(Guid.NewGuid().ToString(), promptTxt);
            else Prompt.AddVariation(promptTxt);
            return this;
        }


    }
}