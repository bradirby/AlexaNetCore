using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore.Directives
{
    public class AlexaUpdateDynamicEntitiesDirective : IAlexaDirective
    {
        public string DirectiveType { get; set; } = "Dialog.UpdateDynamicEntities";
        public string UpdateBehavior { get; set; } = "REPLACE";

        public AlexaUpdateDynamicEntitiesDirective(IList<AlexaSlotUpdate> slots)
        {
            SlotTypes = slots;
        }

        public AlexaUpdateDynamicEntitiesDirective(AlexaSlotUpdate slotUpdate)
        {
            SlotTypes = new List<AlexaSlotUpdate>();
            SlotTypes.Add(slotUpdate);
        }

        public object CreateAlexaResponse(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.type = DirectiveType;
            obj.updateBehavior = "REPLACE";
            obj.types = SlotTypes.Select(s => s.GetJson(locale));

            return obj;
        }


        /// <summary>
        /// the slots to update.
        /// The defined slots must have an ID if they are dynamic
        /// </summary>
        public IList<AlexaSlotUpdate> SlotTypes { get; set; }
    }
}
