namespace AlexaNetCore.Model
{
    public interface IAlexaSlotValidation
    {
        string ValidationType { get; }

        AlexaPrompt Prompt { get; }

        object GetInteractionModel();
    }
}