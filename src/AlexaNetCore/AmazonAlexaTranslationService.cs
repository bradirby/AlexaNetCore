using Amazon.Translate.Model;
using Amazon.Translate;
using System;
using System.Threading.Tasks;

namespace AlexaSkillDotNet
{
    public class AmazonAlexaTranslationService : IAlexaTranslationService
    {
        private IAlexaSkillMessageLogger MsgLogger;

        public string SourceLanguageCode { get; private set; }

        public AmazonAlexaTranslationService(string sourceLanguageCode)
        {
            SourceLanguageCode = sourceLanguageCode;
        }

        public void SetLogger(IAlexaSkillMessageLogger log)
        {
            MsgLogger = log;
        }

        public void SetSourceLanguageCode(string newLanguageCode)
        {
            SourceLanguageCode = newLanguageCode;
        }

        public AmazonAlexaTranslationService(string languageCode, IAlexaSkillMessageLogger log)
        {
            SourceLanguageCode = languageCode;
            MsgLogger = log;
        }

        public async Task<string> TranslateAsync(string toTranslate, string targetLanguageCode)
        {
            using var translateClient = new AmazonTranslateClient(Amazon.RegionEndpoint.USEast1);
            var translateRequest = new TranslateTextRequest
            {
                Text = toTranslate,
                SourceLanguageCode = SourceLanguageCode,
                TargetLanguageCode = targetLanguageCode
            };

            var translateResponse = await translateClient.TranslateTextAsync(translateRequest);

            var outputString = translateResponse?.TranslatedText;

            MsgLogger?.Debug(outputString);

            return outputString;
        }

    }


}
