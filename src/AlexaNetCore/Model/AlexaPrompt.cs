using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// A way of randomly choosing text to speak to the user without the skill
    /// needing to get involved.
    /// </summary>
    public class AlexaPrompt
    {

        /// <summary>
        /// ID of this prompt.  This is necessary for the interaction model.  Using a GUID is allowed and convenient.
        /// </summary>
        public string Id { get; private set; }


        /// <summary>
        /// A list of variations for this prompt.  Variations are different phrases that aim to achieve
        /// the same goal
        /// </summary>
        public List<AlexaPromptVariation> Variations { get; private set; } = new List<AlexaPromptVariation>();


        public AlexaPrompt(string id, AlexaPromptVariation variation)
        {
            Id = id;
            Variations.Add(variation);
        }

        public AlexaPrompt(string id, string variation)
        {
            Id = id;
            Variations.Add(new AlexaPromptVariation(variation));
        }

        public AlexaPrompt(string id, AlexaMultiLanguageText variation)
        {
            Id = id;
            Variations.Add(new AlexaPromptVariation(variation));
        }

        public AlexaPrompt(string id, IEnumerable<AlexaPromptVariation> variations = null)
        {
            if (variations != null) Variations = variations.ToList();
            Id = id;
        }

        public AlexaPrompt(string id, IEnumerable<string> variations = null)
        {
            if (variations != null)
            {
                foreach (var str in variations) Variations.Add(new AlexaPromptVariation(str));
            }
            Id = id;
        }

        public AlexaPrompt(string id, IEnumerable<AlexaMultiLanguageText> variations = null)
        {
            if (variations != null) Variations = variations.Select(v => new AlexaPromptVariation(v)).ToList();
            Id = id;
        }

        public AlexaPrompt AddVariation(string text, string promptType = "PlainText")
        {
            Variations.Add(new AlexaPromptVariation(text, promptType));
            return this;
        }

        public AlexaPrompt AddVariation(AlexaMultiLanguageText text, string promptType = "PlainText")
        {
            Variations.Add(new AlexaPromptVariation(text, promptType));
            return this;
        }

        public object GetInteractionModel(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.id = Id;
            if (Variations != null) obj.variations = Variations.Select(p => p.GetInteractionModel(locale)).ToArray();
            return obj;
        }

    }
}
