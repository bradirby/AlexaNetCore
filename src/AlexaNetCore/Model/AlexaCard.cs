using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AlexaNetCore
{
    /// <summary>
    /// The object containing a card to render to the Amazon Alexa App.
    /// </summary>
    [DataContract]
    public class AlexaCard
    {

        private IAlexaNetCoreMessageLogger MsgLogger;

        public AlexaCard(AlexaCardType typ, IAlexaNetCoreMessageLogger log)
        {
            CardType = typ;
            MsgLogger =log;
        }

        /// <summary>
        /// A string describing the type of card to render. Valid types are:
        ///    "Simple": A card that contains a title and plain text content.
        ///    "Standard": A card that contains a title, text content, and an image to display.
        ///    "LinkAccount": a card that displays a link to an authorization URL that the user can use to link 
        ///       their Alexa account with a user in another system. See Linking an Alexa User with a User in Your System for details.
        ///    "" : do not show the card
        /// </summary>
        /// <remarks>
        /// Getter and setter must be public for the JSON parser
        /// </remarks>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public AlexaCardType CardType{ get; private set; }

        /// <summary>
        /// A string containing the title of the card. (not applicable for cards of type LinkAccount).
        /// </summary>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText Title { get; private set; }

        public void SetTitleText(string titleText)
        {
            Title= new AlexaMultiLanguageText(titleText);
        }

        public void SetTitleText(AlexaMultiLanguageText txt)
        {
            Title = txt;
        }

        /// <summary>
        /// A string containing the contents of a Simple card (not applicable for cards of type Standard or LinkAccount).
        /// Note that you can include line breaks in the content for a card of type Simple. Use either “\r\n” or “\n” within the text of the card to insert line breaks.
        /// </summary>
        [DataMember(Name = "content", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText Content { get; private set; }

        public void SetContentText(string txt)
        {
            Content= new AlexaMultiLanguageText(txt);
        }
        public void SetContentText(AlexaMultiLanguageText txt)
        {
            Content = txt;
        }

        /// <summary>
        /// A string containing the text content for a Standard card (not applicable for cards of type Simple or LinkAccount)
        /// Note that you can include line breaks in the text for a Standard card.Use either “\r\n” or “\n” within the text of the card to insert line breaks.
        /// </summary>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = true)]
        public AlexaMultiLanguageText Text { get; private set; }

        public void SetText(string txt)
        {
            Text= new AlexaMultiLanguageText(txt);
        }

        public void SetText(AlexaMultiLanguageText txt)
        {
            Text = txt;
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

        public void SetImageLink(AlexaImageLink img)
        {
            Image = img;
        }

        public void Validate()
        {
            //https://developer.amazon.com/en-US/docs/alexa/custom-skills/request-and-response-json-reference.html
            //All of the text included in a card can't exceed 8000 characters. This includes the title, content, text, and image URLs.
            //An image URL (smallImageUrl or largeImageUrl) can't exceed 2000 characters.
            var totalLen = 0;

            if (Image != null)
            {
                if (Image.LargeImageUrl.Length > 2000)
                    MsgLogger.Error("Large image link in Card exceeds 2000 character limit");
                if (Image.SmallImageUrl.Length > 2000)
                    MsgLogger.Error("Small image link in Card exceeds 2000 character limit");

                if (!string.IsNullOrEmpty(Image.LargeImageUrl)) totalLen += Image.LargeImageUrl.Length;
                if (!string.IsNullOrEmpty(Image.SmallImageUrl)) totalLen += Image.SmallImageUrl.Length;
            }

            //if (!string.IsNullOrEmpty(Title.GetText())) totalLen += Title.GetText().Length;
            //if (!string.IsNullOrEmpty(Content)) totalLen += Content.Length;
            //if (!string.IsNullOrEmpty(Text.GetText())) totalLen += Text.GetText().Length;
            //if (totalLen > 8000)
            //    MsgLogger.Error("Total card text length exceeds 8000 character limit");
        }


        public object GetJson(AlexaLocale targetLocale, IAlexaTranslationService translator = null)
        {
            dynamic obj = new ExpandoObject();
            obj.type = CardType.ToString();
            if (CardType == AlexaCardType.Simple || CardType == AlexaCardType.Standard)
                obj.title = Title?.GetText(targetLocale, translator);

            if (CardType == AlexaCardType.Simple) obj.content = Content?.GetText(targetLocale, translator);
            else if (CardType == AlexaCardType.Standard) obj.text = Text?.GetText(targetLocale, translator);

            if (Image != null)
            {
                var imgObj = Image.GetJson();
                if (imgObj != null) obj.image = imgObj;
            }
            return obj;

        }
    }
}