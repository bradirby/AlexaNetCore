using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using AlexaNetCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// The object containing a card to render to the Amazon Alexa App.
    /// </summary>
    [DataContract]
    public class AlexaCard
    {

        private ILogger MsgLogger;

        public AlexaCard(AlexaCardType typ, string title, string text, ILogger log = null)
        {
            CardType = typ;
            MsgLogger = log;
            SetTitleText(title);
            SetText(text);
        }

        public AlexaCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null, ILogger log = null)
        {
            MsgLogger = log;
            CardType = urlLink == null ? AlexaCardType.Simple : AlexaCardType.Standard;
            SetTitleText(title);
            SetContentText(txt);
            SetText(txt);
            SetImageLink(urlLink);
        }

        public AlexaCard(string title, string txt, AlexaImageLink urlLink = null, ILogger log = null)
        {
            MsgLogger = log;
            CardType = urlLink == null ? AlexaCardType.Simple : AlexaCardType.Standard;
            SetTitleText(title);
            SetContentText(txt);
            SetText(txt);
            SetImageLink(urlLink);
        }

        /// <summary>
        /// A string describing the type of card to render. Valid types are:
        ///    "Simple": A card that contains a title and plain text content.
        ///    "Standard": A card that contains a title, text content, and an image to display.
        ///    "LinkAccount": a card that displays a link to an authorization URL that the user can use to link 
        ///       their Alexa account with a user in another system. See Linking an Alexa User with a User in Your System for details.
        ///    "" : do not show the card
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public AlexaCardType CardType { get; private set; }

        /// <summary>
        /// A string containing the title of the card. (not applicable for cards of type LinkAccount).
        /// </summary>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText Title { get; private set; }

        public AlexaCard SetTitleText(string titleText)
        {
            Title = new AlexaMultiLanguageText(titleText);
            return this;
        }

        public AlexaCard SetTitleText(AlexaMultiLanguageText txt)
        {
            Title = txt;
            return this;
        }

        /// <summary>
        /// A string containing the contents of a Simple card (not applicable for cards of type Standard or LinkAccount).
        /// Note that you can include line breaks in the content for a card of type Simple. Use either “\r\n” or “\n” within the text of the card to insert line breaks.
        /// </summary>
        [DataMember(Name = "content", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText SimpleCardContent { get; private set; }

        public AlexaCard SetContentText(string txt)
        {
            SimpleCardContent = new AlexaMultiLanguageText(txt);
            return this;
        }
        public AlexaCard SetContentText(AlexaMultiLanguageText txt)
        {
            SimpleCardContent = txt;
            return this;
        }

        /// <summary>
        /// A string containing the text content for a Standard card (not applicable for cards of type Simple or LinkAccount)
        /// Note that you can include line breaks in the text for a Standard card.Use either “\r\n” or “\n” within the text of the card to insert line breaks.
        /// </summary>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText StandardCardContent { get; private set; }

        public AlexaCard SetText(string txt)
        {
            StandardCardContent = new AlexaMultiLanguageText(txt);
            return this;
        }

        public AlexaCard SetText(AlexaMultiLanguageText txt)
        {
            StandardCardContent = txt;
            return this;
        }

        /// <summary>
        /// An image object that specifies the URLs for the image to display on a Standard card. Only applicable for Standard cards.
        /// </summary>
        [DataMember(Name = "image", IsRequired = false, EmitDefaultValue = false)]
        public AlexaImageLink Image { get; private set; }

        public AlexaImageLink AddImageLink(string smallLink, string largeLink)
        {
            Image = new AlexaImageLink(smallLink, largeLink);
            return Image;
        }

        public AlexaCard SetImageLink(AlexaImageLink img)
        {
            Image = img;
            return this;
        }

        public IList<string> Validate()
        {
            //https://developer.amazon.com/en-US/docs/alexa/custom-skills/request-and-response-json-reference.html
            //All of the text included in a card can't exceed 8000 characters. This includes the title, content, text, and image URLs.
            //An image URL (smallImageUrl or largeImageUrl) can't exceed 2000 characters.
            var totalLen = 0;

            var errLst = new List<string>();

            if (Image != null)
            {
                if (Image.LargeImageUrl.Length > 2000)
                    errLst.Add("Large image link in Card exceeds 2000 character limit");
                if (Image.SmallImageUrl.Length > 2000)
                    errLst.Add("Small image link in Card exceeds 2000 character limit");

                if (!string.IsNullOrEmpty(Image.LargeImageUrl)) totalLen += Image.LargeImageUrl.Length;
                if (!string.IsNullOrEmpty(Image.SmallImageUrl)) totalLen += Image.SmallImageUrl.Length;
            }

            if (!string.IsNullOrEmpty(Title.GetText())) totalLen += Title.GetText().Length;
            if (StandardCardContent != null) totalLen += StandardCardContent.GetText().Length;
            if (totalLen > 8000) errLst.Add("Total card text length exceeds 8000 character limit");

            return errLst;
        }


        public object CreateAlexaResponse(AlexaLocale targetLocale)
        {
            dynamic obj = new ExpandoObject();
            obj.type = CardType.ToString();
            if (CardType == AlexaCardType.Simple || CardType == AlexaCardType.Standard)
                obj.title = Title?.GetText(targetLocale);

            if (CardType == AlexaCardType.Simple) obj.content = SimpleCardContent?.GetText(targetLocale);
            else if (CardType == AlexaCardType.Standard) obj.text = StandardCardContent?.GetText(targetLocale);

            if (Image != null)
            {
                var imgObj = Image.GetJson();
                if (imgObj != null) obj.image = imgObj;
            }
            return obj;

        }
    }
}