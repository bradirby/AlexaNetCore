using System;
using System.Dynamic;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class AlexaTextBriefingItem
    {

        /// <summary>
        /// This is a unique identifier for this feed item so Alexa can keep track of whether a feed item has been played
        /// yet.  Changing this id makes this feed item a "new" item so Alexa will consider it to be unplayed.
        /// </summary>
        public Guid FeedId { get; private set; } = Guid.NewGuid();

        public AlexaTextBriefingItem SetFeedId(Guid newId)
        {
            FeedId = newId;
            return this;
        }



        /// <summary>
        /// The date the briefing item was created, in UTC format.
        /// </summary>
        public DateTime BriefingUTCDate { get; private set; } = DateTime.Today;

        public AlexaTextBriefingItem SetUTCDate(DateTime utcDate)
        {
            BriefingUTCDate = utcDate;
            return this;
        }

        /// <summary>
        /// The title that is displayed on the screen (if there is one).  This text is not read aloud but is shown on the Alexa app.
        /// </summary>
        public AlexaMultiLanguageText Title { get; private set; }


        /// <summary>
        /// Sets the title that is displayed on the screen (if there is one).  This text is not read aloud but is shown on the Alexa app.
        /// </summary>
        public AlexaTextBriefingItem SetTitle(string title)
        {
            Title = new AlexaMultiLanguageText(title);
            return this;
        }

        /// <summary>
        /// Sets the title that is displayed on the screen (if there is one).  This text is not read aloud but is shown on the Alexa app.
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
        public string DisplayUrl { get; private set; }


        public AlexaTextBriefingItem SetDisplayUrl(string url)
        {
            DisplayUrl = url;
            return this;
        }

        public object GetResponse(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.uid = $"urn:uuid:{FeedId}";
            obj.updateDate = BriefingUTCDate;
            obj.titleText = Title.GetText(locale);
            obj.mainText = Content.GetText(locale);
            if (!string.IsNullOrEmpty(DisplayUrl))
                obj.redirectionUrl = DisplayUrl;
            return obj;
        }

    }
}