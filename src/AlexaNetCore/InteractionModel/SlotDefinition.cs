using System;
using System.Text;

namespace AlexaNetCore.InteractionModel
{
    public class SlotDefinition
    {
        public string Name { get; set; }


        public string SlotType { get; set; }


        public bool AllowMultipleValues{ get; set; }


        public SlotDefinition(string name, string typ, bool allowMultipleValues )
        {
            Name = name;
            SlotType = typ;
            AllowMultipleValues = allowMultipleValues;
        }

        public SlotDefinitionInteractionModel GetInteractionModel()
        {
            return new SlotDefinitionInteractionModel(Name, SlotType, AllowMultipleValues);
        }

    }
}
