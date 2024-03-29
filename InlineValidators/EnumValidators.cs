﻿using System;

namespace InlineValidators;

public static partial class IV
{
    /// <summary>
    /// Checks the provided parameter to ensure that the value is a valid enum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <returns>The validated parameter value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not valid for its enum.</exception>
    public static T EnsureIsValidEnum<T>(string parameterName, T parameterValue, string? message = null)
        where T : Enum
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        if (!Enum.IsDefined(typeof(T), parameterValue))
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage("The parameter value is not valid for the enum.", message));
        }

        return parameterValue;
    }

    /// <summary>
    /// Checks the provided parameter to ensure that the value is a valid enum value, and the value is not the default enum value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <returns>The validated parameter value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The parameter value is not valid for its enum, or the value is the default for the enum.</exception>
    public static T EnsureIsValidEnumAndNotDefault<T>(string parameterName, T parameterValue, string? message = null)
        where T : Enum
    {
        EnsureIsValidEnum(parameterName, parameterValue, message);

        if (parameterValue.Equals(default(T)))
        {
            throw new ArgumentOutOfRangeException(parameterName, ErrorMessageBuilder.CreateErrorMessage("The parameter value cannot be the default enum value.", message));
        }

        return parameterValue;
    }
}
