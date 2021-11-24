using System;

namespace InlineValidators;

public static partial class IV
{
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
