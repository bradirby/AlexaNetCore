using System;
using System.Dynamic;
using System.Text.Json.Serialization;
using AlexaNetCore.Directives;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class AlexaTextBriefingItem
    {
        public string JsonId => $"urn:uuid:{Id}";

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime BriefingDate { get; set; } = DateTime.Today;


        /// <summary>
        /// The title that is displayed on the screen (if there is one).  This text is not read aloud
        /// </summary>
        public AlexaMultiLanguageText Title { get; private set; }


        /// <summary>
        /// Sets the title that is displayed on the screen (if there is one).  This text is not read aloud
        /// </summary>
        public AlexaTextBriefingItem SetTitle(string title)
        {
            Title = new AlexaMultiLanguageText(title);
            return this;
        }

        /// <summary>
        /// Sets the title that is displayed on the screen (if there is one).  This text is not read aloud
        /// </summary>
        public AlexaTextBriefingItem SetTitle(AlexaMultiLanguageText title)
        {
            Title = title;
            return this;
        }


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


        /// <summary>
        /// Provides the URL target for the Read More link in the Alexa app. "
        /// </summary>
        [JsonPropertyName("redirectionUrl")] 
        public string DisplayUrl { get; private set; }


        public AlexaTextBriefingItem SetDisplayUrl(string url)
        {
            DisplayUrl = url;
            return this;
        }

        public object GetResponse(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.uid = JsonId;
            obj.updateDate = BriefingDate;
            obj.titleText = Title.GetText(locale);
            obj.mainText = Content.GetText(locale);
            if (!string.IsNullOrEmpty(DisplayUrl))
                obj.redirectionUrl = DisplayUrl;
            return obj;
        }

    }
}