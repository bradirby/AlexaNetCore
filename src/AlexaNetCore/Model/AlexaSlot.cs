using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using AlexaNetCore.InteractionModel;

namespace AlexaNetCore.Model
{

    /// <summary>
    /// This is the slot definition where you define the parameters of the slot.  If you are looking for
    /// the instance of a slot that is provided to your code in the Request json, check <see cref="RequestModel.AlexaRequestSlot"/> 
    /// </summary>
    public class AlexaSlot
    {
        public string Name { get; set; }


        public string SlotType { get; set; }
        public List<IAlexaSlotValidation> Validations { get; set; }


        public bool AllowMultipleValues { get; set; }

        private AlexaRequiredSlot Requirements { get; set; }

        public int SlotOrder { get; set; }

        public AlexaSlot(string name, string typ, bool allowMultipleValues)
        {
            Name = name;
            SlotType = typ;
            AllowMultipleValues = allowMultipleValues;
        }


        /// <summary>
        /// When this slot is part of a dialog, this sets the order in which the slots are filled by the device.
        /// I there is no dialog, the slot order is ignored.
        /// </summary>
        public AlexaSlot SetSlotOrder(int order)
        {
            SlotOrder = order;
            return this;
        }

        internal object GetInteractionModelForIntent()
        {
            dynamic obj = new ExpandoObject();
            obj.name = Name;
            obj.type = SlotType;
            if (AllowMultipleValues)
            {
                dynamic multivalObj = new ExpandoObject();
                multivalObj.enabled = AllowMultipleValues;
                obj.multipleValues = multivalObj;
            }

            if (IsRequired) obj.samples = Requirements.UserUtterances.ToArray();

            return obj;
        }


        internal object GetInteractionModelForDialog()
        {
            dynamic obj = new ExpandoObject();
            obj.name = Name;
            obj.type = SlotType;

            if (Requirements == null)
            {
                obj.confirmationRequired = false;
                obj.elicitationRequired = false;
                obj.prompts = new ExpandoObject();
            }
            else if ( Requirements.ElicitationRequired || Requirements.ConfirmationRequired)
            {
                obj.confirmationRequired = Requirements.ConfirmationRequired;
                obj.elicitationRequired = Requirements.ElicitationRequired;

                dynamic promptObj = new ExpandoObject();
                if (Requirements.ConfirmationRequired) promptObj.confirmation = Requirements.Confirmation.ConfirmationPrompt.Id;
                if (Requirements.ElicitationRequired) promptObj.elicitation = Requirements.ElicitationPrompt.Id;
                obj.prompts = promptObj;
            }

            if (Validations != null && Validations.Any())
            {
                obj.validations = Validations.Select(v => v.GetInteractionModel()).ToArray();
            }

            return obj;
        }


        /// <summary>
        /// Add validation for the users answer.  Validation failure will cause the Echo device to reprompt for the value.
        /// You can use slot validation with both required and non-required slots. This lets you validate optional values
        /// if they are provided, but not force the user to fill those slots
        /// <see href="https://developer.amazon.com/en-US/docs/alexa/custom-skills/validate-slot-values.html#delegate">Full Ref Here</see>
        /// </summary>
        /// <param name="validation"></param>
        public AlexaSlot AddSlotValidation(IAlexaSlotValidation validation)
        {
            Validations ??= new List<IAlexaSlotValidation>();
            Validations.Add(validation);
            return this;
        }


        /// <summary>
        /// Removes all validations from the slot
        /// </summary>
        public AlexaSlot RemoveAllValidations()
        {
            Validations = null;
            return this;
        }

        public bool IncludeInDialog => IsRequired || HasValidations;
        public bool IsRequired => Requirements != null;
        public bool HasValidations => Validations != null;


        /// <summary>
        /// Tell the Echo device to prompt for this slot if it is missing.
        /// </summary>
        /// <param name="req">Parameters for how to enforce the required slot</param>
        public AlexaSlot MakeSlotRequired(AlexaRequiredSlot req)
        {
            Requirements = req;
            return this;
        }

        /// <summary>
        /// Remove the requirement for a value in this slot
        /// </summary>
        public AlexaSlot MakeSlotOptional()
        {
            Requirements = null;
            return this;
        }


        internal IEnumerable<AlexaPrompt> GetAllPrompts()
        {
            var lst = new List<AlexaPrompt>();

            if (IsRequired) lst.AddRange(Requirements.GetAllPrompts());

            if (Validations != null) lst.AddRange(Validations.Select(v => v.Prompt));

            return lst;
        }
    }
}
