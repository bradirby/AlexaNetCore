using System;
using System.Dynamic;
using System.Runtime.Serialization;

namespace AlexaNetCore.Model
{
    [DataContract]
    public class AlexaImageLink
    {
        [DataMember(Name = "smallImageUrl", IsRequired = true, EmitDefaultValue = true)]
        public string SmallImageUrl
        {
            get => _smallUrl;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _smallUrl = string.Empty;
                    return;
                }
                if (!IsValidUrl(value)) throw new ArgumentException("Given string is not a valid URL");
                _smallUrl = value;
            }
        }
        private string _smallUrl;

        private bool IsValidUrl(string str)
        {
            return Uri.TryCreate(str, UriKind.Absolute, out var uriResult) 
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }


        [DataMember(Name = "largeImageUrl", IsRequired = true, EmitDefaultValue = true)]
        public string LargeImageUrl 
        {
            get => _largeUrl;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _largeUrl = string.Empty;
                    return;
                }
                if (!IsValidUrl(value)) throw new ArgumentException("Given string is not a valid URL");
                _largeUrl = value;
            }
        }


        private string _largeUrl;


        /// <summary>
        /// Every image shown on a screen must have two versions - a small and large.  
        /// </summary>
        /// <param name="smallImgUrl">The full small image URL, such as https://MyCoolApp.s3.amazonaws.com/Small.png</param>
        /// <param name="largeImgUrl">The full large image URL, such as https://MyCoolApp.s3.amazonaws.com/Small.png</param>
        public AlexaImageLink(string smallImgUrl, string largeImgUrl)
        {
            SmallImageUrl = smallImgUrl;
            LargeImageUrl = largeImgUrl;
        }

        public object GetJson()
        {
            if (string.IsNullOrEmpty(SmallImageUrl + LargeImageUrl)) return null;

            dynamic obj = new ExpandoObject();
            if (!string.IsNullOrEmpty(SmallImageUrl)) obj.smallImageUrl = SmallImageUrl;
            if (!string.IsNullOrEmpty(LargeImageUrl)) obj.largeImageUrl = LargeImageUrl;
       
            return obj;

        }
    }
}