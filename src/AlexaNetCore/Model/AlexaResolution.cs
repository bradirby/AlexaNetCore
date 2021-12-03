using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaResolution
    {
        [JsonPropertyName("resolutionsPerAuthority")]
        public List<AlexaResolutionPerAuthority> ResolutionsPerAuthority { get; set; }

    }
}