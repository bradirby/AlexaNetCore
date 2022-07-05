using AlexaNetCore.Model;
using System.Dynamic;

namespace AlexaNetCore.Interfaces
{
    /// <summary>
    /// Directives are added to the response model and tell the AI to perform the requested action
    /// </summary>
    /// <remarks>
    /// https://developer.amazon.com/en-US/docs/alexa/custom-skills/dialog-interface-reference.html
    /// </remarks>
    public interface IAlexaDirective
    {
        string DirectiveType { get; set; }
        object CreateAlexaResponse(AlexaLocale locale);
    }
}