using System.Collections.Generic;

namespace AlexaNetCore.Model
{
    public class AlexaUpdatedIntent
    {
        public string Name { get; set; }
        public string ConfirmationStatus { get; set; } = "NONE";
        private List<AlexaUpdatedIntentSlot> Slots { get; set; } = new List<AlexaUpdatedIntentSlot>();
        public AlexaUpdatedIntent(string intentName)
        {
            Name = intentName;
        }

        public AlexaUpdatedIntent AddSlot(string name, string value = "", string confirmationStatus = "NONE")
        {
            Slots.Add(new AlexaUpdatedIntentSlot(name, confirmationStatus, value));
            return this;
        }

        private class AlexaUpdatedIntentSlot
        {
            public string Name { get; set; }
            public string ConfirmationStatus { get; set; } = "NONE";
            public string Value { get; set; }
            public AlexaUpdatedIntentSlot(string name, string confirmationStatus, string value)
            {
                Name = name;
                ConfirmationStatus = confirmationStatus;
                Value = value;
            }
        }
    }
}