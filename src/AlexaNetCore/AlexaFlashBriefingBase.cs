using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace AlexaNetCore
{
    public abstract class AlexaFlashBriefingBase : AlexaObjectBase
    {
        
        protected internal List<AlexaTextBriefingItem> Items { get; set; }

        public AlexaFlashBriefingBase()
        {
            Items = new List<AlexaTextBriefingItem>();
        }

        public AlexaFlashBriefingBase AddFlashBriefing(AlexaTextBriefingItem item)
        {
            Items.Add(item);
            return this;
        }

        public abstract AlexaFlashBriefingBase ProcessRequest();

        /// <summary>
        /// Creates a JSON response appropriate for consumption by an Echo
        /// </summary>
        public string CreateAlexaResponse()
        {
            if (Items.Count == 1) return Serialize(Items.First());
            return Serialize(Items.ToArray());
        }
    }
}
