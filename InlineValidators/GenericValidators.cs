using System;

namespace InlineValidators;

public static partial class IV
{
    /// <summary>
    /// Checks the provided parameter to ensure that the value is not null.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <returns>A non-nullable variant of the parameter value.</returns>
    /// <exception cref="ArgumentNullException">The parameter value is null.</exception>
    public static T EnsureNotNull<T>(string parameterName, T? parameterValue, string? message = null)
        where T : struct
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        if (parameterValue == null)
        {
            throw new ArgumentNullException(parameterName, ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null.", message));
        }

        return parameterValue.Value;
    }

    /// <summary>
    /// Checks the provided parameter to ensure that the value is not null or empty.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <returns>A non-nullable variant of the parameter value.</returns>
    /// <exception cref="ArgumentNullException">The parameter value is null.</exception>
    /// <exception cref="ArgumentException">The parameter value is empty.</exception>
    public static T EnsureNotNull<T>(string parameterName, T? parameterValue, string? message = null)
        where T : class
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        if (parameterValue == null)
        {
            throw new ArgumentNullException(parameterName, ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null.", message));
        }

        return parameterValue;
    }
}
