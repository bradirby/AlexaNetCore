using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Amazon.Runtime.Internal;

namespace AlexaSkillDotNet
{
    public class AlexaSlot
    {

        [JsonPropertyName("name")]
        public virtual string Name { get; set; }

        [JsonPropertyName("value")]
        public virtual string Value { get; set; }

        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; } 

        [JsonPropertyName("confirmationStatus")]
        public virtual string ConfirmationStatus{ get; set; }

        [JsonPropertyName("source")]
        public virtual string Source{ get; set; }

        [JsonPropertyName("slotValue")]
        public AlexaSlotValue SlotValue { get; set; }
    }
}