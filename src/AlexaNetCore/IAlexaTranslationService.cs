using System.Threading.Tasks;

namespace AlexaSkillDotNet
{

    /// <summary>
    /// The speech generation will call the Translator service if it is specified.
    /// </summary>
    public interface IAlexaTranslationService
    {
        Task<string> TranslateAsync(string toTranslate, string targetLanguageCode);

        void SetLogger(IAlexaSkillMessageLogger log);

        void SetSourceLanguageCode(string newLanguageCode);

        string SourceLanguageCode { get; }


    }
}