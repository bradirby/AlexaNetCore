using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaResolution
    {
        /// <summary>
        /// An array of the different authorities used when trying to match what the user said to the array of options
        /// provided in the interaction model.  These are in no particular order
        /// </summary>
        [JsonPropertyName("resolutionsPerAuthority")]
        public AlexaResolutionPerAuthority[] ResolutionsPerAuthority { get; set; }

    }
}