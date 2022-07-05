using AlexaNetCore.InteractionModel;
using AlexaNetCore.Model;

namespace AlexaNetCore.Util
{
    public static class SlotTypeFactory
    {
      
        public static void BuildUSFederalHolidaySlot(this AlexaSkillBase skill, string slotTypeName)
        {
            skill.AddCustomSlotType(new AlexaCustomSlotType(slotTypeName)
                .AddValueOption( "allsaints","All Saints Day")
                .AddValueOption( "ptaconf","Parent Teacher Conference")
                .AddValueOption( "springbreak","Spring Break", new [] {"Ski Week"})
                .AddValueOption( "immaculateconception","Immaculate Conception")
                .AddValueOption( "liberationday","Liberation Day")
                .AddValueOption( "republicday","Republic Day")
                .AddValueOption( "summer","Summer Break")
                .AddValueOption( "easter","Easter", new [] {"Easter Break"})
                .AddValueOption( "christmas","Christmas", new [] {"Christmas Break"})
                .AddValueOption( "turkey","Thanksgiving", new [] {"Turkey day"}));

        }

        /// <summary>
        /// The built in slot type AMAZON.US_STATES is not supported in other languages so we need to add it by hand.
        /// </summary>
        public static void BuildUSStateSlot(this AlexaSkillBase skill, string slotTypeName)
        {
            skill.AddCustomSlotType(new AlexaCustomSlotType(slotTypeName)
            .AddValueOption( "Alabama")
            .AddValueOption( "Alaska")
            .AddValueOption( "Arizona")
            .AddValueOption( "Arkansas")
            .AddValueOption( "California")
            .AddValueOption( "Colorado")
            .AddValueOption( "Connecticut")
            .AddValueOption( "Delaware")
            .AddValueOption( "Florida")
            .AddValueOption( "Georgia")
            .AddValueOption( "Hawaii")
            .AddValueOption( "Idaho")
            .AddValueOption( "Illinois")
            .AddValueOption( "Indiana")
            .AddValueOption( "Iowa")
            .AddValueOption( "Kansas")
            .AddValueOption( "Kentucky")
            .AddValueOption( "Louisiana")
            .AddValueOption( "Maine")
            .AddValueOption( "Maryland")
            .AddValueOption( "Massachusetts")
            .AddValueOption( "Michigan")
            .AddValueOption( "Minnesota")
            .AddValueOption( "Mississippi")
            .AddValueOption( "Missouri")
            .AddValueOption( "Montana")
            .AddValueOption( "Nebraska")
            .AddValueOption( "Nevada")
            .AddValueOption( "New Hampshire")
            .AddValueOption( "New Jersey")
            .AddValueOption( "New Mexico")
            .AddValueOption( "New York")
            .AddValueOption( "North Carolina")
            .AddValueOption( "North Dakota")
            .AddValueOption( "Ohio")
            .AddValueOption( "Oklahoma")
            .AddValueOption( "Oregon")
            .AddValueOption( "Pennsylvania")
            .AddValueOption( "Rhode Island")
            .AddValueOption( "South Carolina")
            .AddValueOption( "South Dakota")
            .AddValueOption( "Tennessee")
            .AddValueOption( "Texas")
            .AddValueOption( "Utah")
            .AddValueOption( "Vermont")
            .AddValueOption( "Virginia")
            .AddValueOption( "Washington")
            .AddValueOption( "West Virginia")
            .AddValueOption( "Wisconsin")
            .AddValueOption( "Wyoming"));
        }
     
        
        public static void BuildMetricAndImperialMeasureSlot(this AlexaSkillBase skill, string slotTypeName)
        {
            var measureSlotType = new AlexaCustomSlotType(slotTypeName);

            var txt = new AlexaMultiLanguageText("inches", AlexaLocale.English_US)
                .AddText("pulgados", AlexaLocale.Spanish_ES)
                .AddText("pollici", AlexaLocale.Italian);
            var synonym = new AlexaMultiLanguageText("inch", AlexaLocale.English_US)
                .AddText("pulgado", AlexaLocale.Spanish_ES)
                .AddText("pollice", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("feet", AlexaLocale.English_US)
                .AddText("pies", AlexaLocale.Spanish_ES)
                .AddText("piedi", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("foot", AlexaLocale.English_US)
                .AddText("pie", AlexaLocale.Spanish_ES)
                .AddText("piede", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("yards", AlexaLocale.English_US)
                .AddText("yardas", AlexaLocale.Spanish_ES)
                .AddText("iarde", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("yard", AlexaLocale.English_US)
                .AddText("yarda", AlexaLocale.Spanish_ES)
                .AddText("iarda", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("miles", AlexaLocale.English_US)
                .AddText("millas", AlexaLocale.Spanish_ES)
                .AddText("miglia", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("mile", AlexaLocale.English_US)
                .AddText("milla", AlexaLocale.Spanish_ES)
                .AddText("miglio", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("millimeters", AlexaLocale.English_US)
                .AddText("milimetros", AlexaLocale.Spanish_ES)
                .AddText("millimetri", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("millimeter", AlexaLocale.English_US)
                .AddText("milimetro", AlexaLocale.Spanish_ES)
                .AddText("millimetro", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("centimeters", AlexaLocale.English_US)
                .AddText("centimetros", AlexaLocale.Spanish_ES)
                .AddText("centimetri", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("centimeter", AlexaLocale.English_US)
                .AddText("centimetro", AlexaLocale.Spanish_ES)
                .AddText("centimetro", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("meters", AlexaLocale.English_US)
                .AddText("metros", AlexaLocale.Spanish_ES)
                .AddText("metri", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("meter", AlexaLocale.English_US)
                .AddText("metro", AlexaLocale.Spanish_ES)
                .AddText("metro", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            txt = new AlexaMultiLanguageText("kilometers", AlexaLocale.English_US)
                .AddText("kilometros", AlexaLocale.Spanish_ES)
                .AddText("chilometri", AlexaLocale.Italian);
            synonym = new AlexaMultiLanguageText("kilometer", AlexaLocale.English_US)
                .AddText("kilometro", AlexaLocale.Spanish_ES)
                .AddText("chilometro", AlexaLocale.Italian);
            measureSlotType.AddValueOption(txt,new [] {synonym});

            skill.AddCustomSlotType(measureSlotType);
        }
    }
}
