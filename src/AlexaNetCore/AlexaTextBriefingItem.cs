using System;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaTextBriefingItem
    {
        [JsonPropertyName("uid")] 
        public string JsonId => $"urn:uuid:{Id}";

        [JsonIgnore] 
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("updateDate")] 
        public DateTime BriefingDate { get; set; } = DateTime.Today;

        [JsonPropertyName("titleText")] 
        public AlexaMultiLanguageText Title { get; private set; }

        public AlexaTextBriefingItem SetTitle(string title)
        {
            Title = new AlexaMultiLanguageText(title);
            return this;
        }

        public AlexaTextBriefingItem SetTitle(AlexaMultiLanguageText title)
        {
            Title = title;
            return this;
        }

        [JsonPropertyName("mainText")] 
        public AlexaMultiLanguageText Content { get; private set; }

        public AlexaTextBriefingItem SetContent(string title)
        {
            Content = new AlexaMultiLanguageText(title);
            return this;
        }

        public AlexaTextBriefingItem SetContent(AlexaMultiLanguageText title)
        {
            Content = title;
            return this;
        }


        [JsonPropertyName("redirectionUrl")] 
        public string DisplayUrl { get; private set; }

        public AlexaTextBriefingItem SetDisplayUrl(string url)
        {
            DisplayUrl = url;
            return this;
        }

    }
}