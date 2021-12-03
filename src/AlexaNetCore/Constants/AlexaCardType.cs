namespace AlexaSkillDotNet
{
    public enum AlexaCardType
    {
        //https://developer.amazon.com/en-US/docs/alexa/custom-skills/request-and-response-json-reference.html


        /// <summary>
        /// A card that contains a title and plain text content.
        /// </summary>
        Simple, 

        /// <summary>
        /// A card that contains a title, text content, and an image to display.
        /// </summary>
        Standard,

        /// <summary>
        /// A card that displays a link to an authorization URI that the user can use to link their Alexa account with a user in another system. See Account Linking for Custom Skills for details.
        /// </summary>
        LinkAccount,

        /// <summary>
        /// A card that asks the customer for consent to obtain specific customer information, such as Alexa lists or address information.
        /// </summary>
        AskForPermissionsConsent
    }
}
