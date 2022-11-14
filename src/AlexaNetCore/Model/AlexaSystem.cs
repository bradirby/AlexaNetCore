using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaSystem
    {
        [JsonPropertyName("application")]
        public AlexaApplication Application { get; set; }

        [JsonPropertyName("user")]
        public AlexaUser User { get; set; }

        [JsonPropertyName("person")]
        public AlexaPerson Person{ get; set; }

        [JsonPropertyName("usuniter")]
        public AlexaUnit Unit { get; set; }


        [JsonPropertyName("device")]
        public AlexaDevice Device { get; set; }

        [JsonPropertyName("apiEndpoint")]
        public string ApiEndpoint { get; set; }

        [JsonPropertyName("apiAccessToken")]
        public string ApiAccessToken { get; set; }
    }


    public class AlexaPerson
    {
        [JsonPropertyName("personId")]
        public string PersonId { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }

    public class AlexaUnit
    {
        [JsonPropertyName("unitId")]
        public string UnitId { get; set; }

        [JsonPropertyName("persistentUnitId")]
        public string PersistentUnitId { get; set; }
    }
}