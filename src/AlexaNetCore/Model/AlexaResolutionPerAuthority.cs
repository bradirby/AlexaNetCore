using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaResolutionPerAuthority
    {
        [JsonPropertyName("authority")]
        public string Authority { get; set; }

        [JsonPropertyName("status")]
        public AlexaResolutionPerAuthorityStatus Status { get; set; }

        [JsonPropertyName("values")]
        public List<AlexaResolutionValue> Values { get; set; } 
    }

    public class AlexaResolutionPerAuthorityStatus
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}