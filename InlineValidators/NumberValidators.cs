using System;

namespace InlineValidators;

public static partial class IV
{
    /// <summary>
    /// Checks the provided parameter to make sure that it is not null and is greater than the specified minimum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="minimumValue">The value that the <paramref name="parameterValue"/> must be greater than.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not greater than the specified minimum value.</exception>
    public static double EnsureIsGreaterThan(string parameterName, double? parameterValue, double minimumValue, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        var notNullValue = EnsureNotNull(parameterName, parameterValue, message);

        if (notNullValue <= minimumValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage($"The parameter must be greater than '{minimumValue}'.", message));
        }

        return notNullValue;
    }

    /// <summary>
    /// Checks the provided parameter to make sure that it is not null and is greater than or equal to the specified minimum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="minimumValue">The value that the <paramref name="parameterValue"/> must be greater than or equal to.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not greater than or equal to the specified minimum value.</exception>
    public static double EnsureIsGreaterThanOrEqualTo(string parameterName, double? parameterValue, double minimumValue, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        var notNullValue = EnsureNotNull(parameterName, parameterValue, message);

        if (notNullValue < minimumValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage($"The parameter must be greater than or equal to '{minimumValue}'.", message));
        }

        return notNullValue;
    }

    /// <summary>
    /// Checks the provided parameter to make sure that it is not null and is less than the specified maximum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="maximumValue">The value that the <paramref name="parameterValue"/> must be less than.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not less than the specified maximum value.</exception>
    public static double EnsureIsLessThan(string parameterName, double? parameterValue, double maximumValue, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        var notNullValue = EnsureNotNull(parameterName, parameterValue, message);

        if (notNullValue >= maximumValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage($"The parameter must be less than '{maximumValue}'.", message));
        }

        return notNullValue;
    }

    /// <summary>
    /// Checks the provided parameter to make sure that it is not null and is less than or equal to the specified maximum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="maximumValue">The value that the <paramref name="parameterValue"/> must be less than or equal to.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not less than or equal to the specified maximum value.</exception>
    public static double EnsureIsLessThanOrEqualTo(string parameterName, double? parameterValue, double maximumValue, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        var notNullValue = EnsureNotNull(parameterName, parameterValue, message);

        if (notNullValue > maximumValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage($"The parameter must be less than or equal to '{maximumValue}'.", message));
        }

        return notNullValue;
    }
}
