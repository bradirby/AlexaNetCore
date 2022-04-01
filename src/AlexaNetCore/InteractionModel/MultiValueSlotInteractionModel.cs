using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class MultiValueSlotInteractionModel
    {
        [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    }
}