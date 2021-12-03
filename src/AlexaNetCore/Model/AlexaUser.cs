using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaUser
    {
        public AlexaUser()
        {
            
        }

        public AlexaUser(dynamic objDyn)
        {
            try
            {
                UserID = objDyn.userId;
                AccessToken = objDyn.accesstoken;
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }

        /// <summary>
        /// A string that represents a unique identifier for the user who made the request. 
        /// The length of this identifier can vary, but is never more than 255 characters. 
        /// The userId is automatically generated when a user enables the skill in the Alexa 
        /// app. Note that disabling and re-enabling a skill generates a new identifier.
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserID { get; set; }

        /// <summary>
        /// a token identifying the user in another system. This is only provided if the user has successfully linked their account.
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}