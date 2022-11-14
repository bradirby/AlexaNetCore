using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaResolutionPerAuthority
    {
        /// <summary>
        /// Name of the authority used to try to recognize what the user said.
        /// The authority amzn1.er-authority.echo-sdk.amzn1.ask.skill is the original list of items given in the static interaction model.
        /// The authority amzn1.er-authority.echo-sdk.dynamic.amzn1.ask.skill is the updated dynamic list of possible values provided at runtime
        /// </summary>
        [JsonPropertyName("authority")]
        public string Authority { get; set; }

        /// <summary>
        /// Status of the match. The values include:
        ///     "ER_SUCCESS_NO_MATCH" - successfully used the authority but found no matches
        ///     "ER_SUCCESS_MATCH" - successfully used the authority and found a match
        /// </summary>
        [JsonPropertyName("status")]
        public AlexaResolutionPerAuthorityStatus Status { get; set; }


        /// <summary>
        /// If a match was found by this authority, these are the ones that matched.  They are in order of quality of match, best first.
        /// </summary>
        [JsonPropertyName("values")]
        public AlexaResolutionValue[] Values { get; set; } 
    }

    public class AlexaResolutionPerAuthorityStatus
    {
        /// <summary>
        /// Status of the match. The values include:
        ///     "ER_SUCCESS_NO_MATCH" - successfully used the authority but found no matches
        ///     "ER_SUCCESS_MATCH" - successfully used the authority and found a match
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }


        [JsonIgnore]
        public bool IsMatched => Code == "ER_SUCCESS_MATCH";
    }
}