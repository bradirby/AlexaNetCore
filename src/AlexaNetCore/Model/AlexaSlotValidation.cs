using System;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    public interface IAlexaSlotValidation
    {
        string ValidationType { get; }

        AlexaPrompt Prompt { get; }

        object GetInteractionModel();
    }


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

        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;

            return obj;

        }

    }

    /// <summary>
    /// Reject date or time values that fall within a specified time span. If the user's value
    /// is within the specified time span, the value fails validation.
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsNotInDuration<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }
        public string ValidationType { get; set; }= "isNotInDuration";
        private T Start;
        private T End;
        public AlexaSlotValidationIsNotInDuration(T start, T end, AlexaPrompt p)
        {
            Prompt = p;
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

    }

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

        public object GetInteractionModel()
        {
            dynamic obj = new ExpandoObject();
            obj.type = ValidationType;

            if (Prompt != null) obj.prompt = Prompt.Id;
            obj.start = Start;
            obj.end = End;

            return obj;

        }

    }


    /// <summary>
    /// Accept values that are less than or equal to a specified value. If the
    /// user's value is greater than the specified value, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsLessThanOrEqualTo<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }
        public string ValidationType { get; set; }= "isLessThanOrEqualTo";
        private T Item;
        public AlexaSlotValidationIsLessThanOrEqualTo(T item, AlexaPrompt p)
        {
            Prompt = p;
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

    }

    /// <summary>
    /// Accept values that are less than a specified value. If the user's value is greater than
    /// or equal to the specified value, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsLessThan<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }
        public string ValidationType { get; set; }= "isLessThan";
        private T Item;
        public AlexaSlotValidationIsLessThan(T item, AlexaPrompt p)
        {
            Prompt = p;
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

    }

    /// <summary>
    /// Accept values that are less than a specified value. If the user's value is greater than
    /// or equal to the specified value, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsGreaterThanOrEqualTo<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }
        public string ValidationType { get; set; } = "isGreaterThanOrEqualTo";
        private T Item;
        public AlexaSlotValidationIsGreaterThanOrEqualTo(T item, AlexaPrompt p)
        {
            Prompt = p;
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

    }


    /// <summary>
    /// Accept values that are greater than a specified value. If the user's value is
    /// less than or equal to the criteria, the value fails the validation.
    /// This is only valid for AMAZON.DATE, AMAZON.FOUR_DIGIT_NUMBER, AMAZON.NUMBER, AMAZON.TIME
    /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#validation-rules">Full Ref Here</see>
    /// </summary>
    public class AlexaSlotValidationIsGreaterThan<T> : IAlexaSlotValidation
    {
        public AlexaPrompt Prompt { get; set; }

        public string ValidationType { get; set; }= "isGreaterThan";

        private T Item;

        public AlexaSlotValidationIsGreaterThan(T item, AlexaPrompt p)
        {
            Prompt = p;
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

    }
}