using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using System.Dynamic;

namespace AlexaNetCore.Directives
{
    /// <summary>
    /// Clears out all dynamic entity definitions.  this should be called when exiting the session.
    /// </summary>
    internal class AlexaClearDynamicEntitiesDirective : IAlexaDirective
    {

        public string DirectiveType { get; set; } = "Dialog.UpdateDynamicEntities";
        public object CreateAlexaResponse(AlexaLocale locale)
        {
            throw new System.NotImplementedException();
        }


        public AlexaClearDynamicEntitiesDirective()
        {
        }
    }
}