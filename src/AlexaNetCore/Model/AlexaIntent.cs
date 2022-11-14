using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using AlexaNetCore.RequestModel;

namespace AlexaNetCore.Model
{
    public class AlexaIntent
    {
        /// <summary>
        /// A string representing the name of the intent.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }



        [JsonPropertyName("confirmationStatus")]
        public string ConfirmationStatus{ get; set; }

        
        [JsonPropertyName("slots")]
        public Dictionary<string, AlexaRequestSlot> Slots { get; set; } = new Dictionary<string, AlexaRequestSlot>();
        

        internal AlexaRequestSlot GetSlot(string slotName)
        {
            return !Slots.ContainsKey(slotName) ? null : Slots[slotName];
        }


        internal IEnumerable<AlexaRequestSlot> GetAllSlots()
        {
            return Slots.Values.ToList();
        }

        /// <summary>
        /// Updates the value in the given slot, or adds the slot and sets the value
        /// </summary>
        /// <returns>Returns True if the slot already exists, or false if it was added</returns>
        public bool AddOrUpdateSlotValue(string slotName,string newSlotVal)
        {
            if (Slots.ContainsKey(slotName))
            {
                var slot = Slots[slotName];
                slot.Value = newSlotVal;
                return true;
            }

            var newSlot = new AlexaRequestSlot();
            newSlot.Name = slotName;
            newSlot.Value = newSlotVal;
            newSlot.Source = "CODE";   //this is a code introduced here - it's not an official Amazon source
            Slots.Add(newSlot.Name, newSlot);
            return false;

        }
    }
}