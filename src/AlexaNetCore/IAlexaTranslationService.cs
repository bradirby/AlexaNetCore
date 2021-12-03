﻿using System.Threading.Tasks;

namespace AlexaNetCore
{

    /// <summary>
    /// The speech generation will call the Translator service if it is specified.
    /// </summary>
    public interface IAlexaTranslationService
    {
        Task<string> TranslateAsync(string toTranslate, string targetLanguageCode);

        void SetLogger(IAlexaNetCoreMessageLogger log);

        void SetSourceLanguageCode(string newLanguageCode);

        string SourceLanguageCode { get; }


    }
}