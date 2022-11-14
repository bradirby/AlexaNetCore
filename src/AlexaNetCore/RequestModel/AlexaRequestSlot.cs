using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.RequestModel
{

    /// <summary>
    /// An instance of a slot returned to your intent via the Request Envelope.  If you are looking for how to
    /// define a slot, check <see cref="Model.AlexaSlot"/>
    /// </summary>
    public class AlexaRequestSlot
    {

        /// <summary>
        /// The name of the slot.  
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }



        /// <summary>
        /// This is what the AI speech recognition engine thinks the user actually said.
        /// It may or may not be in the list of valid values for the slot.
        /// If you want a value from the list of valid options you can examine each authority and what it things using the Resolutions property,
        /// or use the 
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }


        /// <summary>
        /// This describes the different authorities the AI engine used to resolve what the user said, and the results each came up with
        /// </summary>
        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; }


        /// <summary>
        /// If this slot required confirmation, this says what happened.  A value of "NONE" means Alexa was not asked to confirm the value
        /// </summary>
        [JsonPropertyName("confirmationStatus")]
        public string ConfirmationStatus { get; set; }


        /// <summary>
        /// Where this slot value came from - typically "USER"
        /// </summary>
        [JsonPropertyName("source")]
        public virtual string Source { get; set; }


        /// <summary>
        /// Much of this seems to be a duplication of the Resolutions listed above.  I don't understand how they differ.
        /// This descriptor may be null for slots that have validations.
        /// </summary>
        [JsonPropertyName("slotValue")]
        public AlexaRequestSlotValueDescriptor ValueDescriptor { get; set; }






        /// <summary>
        /// If there are multiple values, this will return the IEnumerable<string>.  Else it returns null
        /// </summary>
        [JsonIgnore]
        public virtual IEnumerable<string> Values
        {
            get
            {
                if (ValueDescriptor == null) return null;
                if (ValueDescriptor.Values == null) return null;
                return ValueDescriptor.Values.Select(v => v.Value);
            }
        }


        /// <summary>
        /// The slot value that best matches what the user said, according to all the available authorities.
        /// This includes the value and the code, if it was specified in the interaction model
        /// </summary>
        [JsonIgnore]
        public AlexaResolutionValue[] BestMatchedValues
        {
            get
            {
                if (Resolutions?.ResolutionsPerAuthority == null) return Array.Empty<AlexaResolutionValue>();

                //todo we could have multiple authorities provide matches but we're randomly selecting the first.  is there a better way?
                var resolvedValues = Resolutions.ResolutionsPerAuthority.FirstOrDefault(r => r.Status.IsMatched);
                if (resolvedValues?.Values == null) return Array.Empty<AlexaResolutionValue>();
                return resolvedValues.Values;
            }
        }


        public bool ContainsMultipleValues
        {
            get
            {
                if (ValueDescriptor == null) return false;
                return ValueDescriptor.ContainsMultipleValues;
            }
        }

    }
}