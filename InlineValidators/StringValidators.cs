using System;

namespace InlineValidators;

/// <summary>
/// Static class for accessing Inline Validators.
/// </summary>
public static partial class IV
{
    /// <summary>
    /// Checks the provided parameter to ensure that the value is not null or empty.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <returns>A non-nullable variant of the parameter value.</returns>
    /// <exception cref="ArgumentNullException">The parameter value is null.</exception>
    /// <exception cref="ArgumentException">The parameter value is empty.</exception>
    public static string EnsureNotNullOrEmpty(string parameterName, string? parameterValue, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        if (parameterValue == null)
        {
            throw new ArgumentNullException(parameterName, ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null or empty.", message));
        }

        if (string.IsNullOrEmpty(parameterValue))
        {
            throw new ArgumentException(ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null or empty.", message), parameterName);
        }

        return parameterValue;
    }

    /// <summary>
    /// Checks the provided parameter to ensure that the value is not null, empty, or whitespace.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message"></param>
    /// <returns>A non-nullable variant of the parameter value.</returns>
    /// <exception cref="ArgumentNullException">The parameter name is null.</exception>
    /// <exception cref="ArgumentException">The parameter name is empty or whitespace.</exception>
    /// <exception cref="ArgumentNullException">The parameter value is null.</exception>
    /// <exception cref="ArgumentException">The parameter value is empty or whitespace.</exception>
    public static string EnsureNotNullOrWhiteSpace(string parameterName, string? parameterValue, string? message = null)
    {
        if (parameterName == null)
        {
            throw new ArgumentNullException(nameof(parameterName), "Invalid parameter. Value can not be null, empty, or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(parameterName))
        {
            throw new ArgumentException("Invalid parameter. Value can not be null, empty, or whitespace.", nameof(parameterName));
        }

        if (parameterValue == null)
        {
            throw new ArgumentNullException(parameterName, ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null, empty, or contain only whitespace characters.", message));
        }

        if (string.IsNullOrWhiteSpace(parameterValue))
        {
            throw new ArgumentException(ErrorMessageBuilder.CreateErrorMessage("Parameter can not be null, empty, or contain only whitespace characters.", message), parameterName);
        }

        return parameterValue;
    }
}
