using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class IntentHandlerInteractionModel
    {
        public IntentHandlerInteractionModel(string name, List<string> invocations)
        {
            IntentName = name;
            Samples = invocations.ToArray();
        }

        [JsonPropertyName("name")] public string IntentName { get;}

        [JsonPropertyName("samples")] public string[] Samples { get; }

    }
}
