using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaContext
    {

        [JsonPropertyName("Viewports")]
        public List<AlexaViewport> Viewports { get; set; }

        [JsonPropertyName("Viewport")]
        public AlexaViewport Viewport { get; set; }

        [JsonPropertyName("System")]
        public AlexaSystem System { get; set; }

        [JsonPropertyName("Extensions")]
        public AlexaContextExtensions Extensions { get; set; }

    }

    public class AlexaContextExtensions
    {

    }
}
