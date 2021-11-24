namespace InlineValidators;

internal static class ErrorMessageBuilder
{
    internal static string CreateErrorMessage(string defaultMessage, string? userProvidedMessage = null)
    {
        return userProvidedMessage ?? defaultMessage;
    }
}
