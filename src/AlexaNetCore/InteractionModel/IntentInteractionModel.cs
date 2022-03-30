using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class IntentInteractionModel
    {
        public IntentInteractionModel(string name, List<string> invocations, List<SlotInteractionModel> slotOptions = null)
        {
            IntentName = name;


            Samples = invocations.ToArray();

            if (slotOptions == null) Slots = null;
            else if (!slotOptions.Any()) Slots = null;
            else Slots = slotOptions.ToArray();
        }

        [JsonPropertyName("name")] public string IntentName { get;}

        [JsonPropertyName("slots")] 
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SlotInteractionModel[] Slots{ get; }


        [JsonPropertyName("samples")] 
        public string[] Samples { get; }

    }
}
