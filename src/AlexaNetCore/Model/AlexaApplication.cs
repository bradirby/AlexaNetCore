using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaApplication
    {

        [JsonPropertyName("applicationId")]
        public string ApplicationId { get; set; }
        
    }
}