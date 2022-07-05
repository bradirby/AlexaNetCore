using System.Dynamic;

namespace AlexaNetCore.Model
{
    public class AlexaPromptVariation
    {
        public string PromptType { get; private set; } = "PlainText";

        public AlexaMultiLanguageText PromptText { get; private set; }

        public AlexaPromptVariation(string prompText, string promptType = "PlainText")
        {
            PromptType = promptType;
            PromptText = new AlexaMultiLanguageText(prompText);

        }

        public AlexaPromptVariation(AlexaMultiLanguageText prompText, string promptType = "PlainText")
        {
            PromptType = promptType;
            PromptText = prompText;
        }

        public object GetInteractionModel(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.type = PromptType;
            obj.value = PromptText.GetText(locale);
            return obj;
        }
    }
}