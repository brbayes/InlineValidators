using System;
using System.Collections.Generic;
using System.Linq;

namespace InlineValidators;

public static partial class IV
{
    /// <summary>
    /// Checks the provided <see cref="IEnumerable{T}"/> parameter to make sure that it is not null and is not empty.
    /// </summary>
    /// <typeparam name="T">The type of element used in the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value is null or is empty.</exception>
    public static void EnsureNotNullOrEmpty<T>(string parameterName, IEnumerable<T>? parameterValue, string? message = null) =>
        EnsureHasMinimumCount(parameterName, parameterValue, 1, message);

    /// <summary>
    /// Checks the provided <see cref="IEnumerable{T}"/> parameter to make sure that it is not null and has a sufficient number of elements.
    /// </summary>
    /// <typeparam name="T">The type of element used in the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="parameterName">The name of the parameter that is being checked.</param>
    /// <param name="parameterValue">The value of the parameter that is being checked.</param>
    /// <param name="minimumCount">The minimum number of elements that must exist in the collection. This parameter cannot be less than 0.</param>
    /// <param name="message">An optional custom message to include if an exception is thrown.</param>
    /// <exception cref="ArgumentException">The parameter value has fewer elements than is required.</exception>
    public static void EnsureHasMinimumCount<T>(string parameterName, IEnumerable<T>? parameterValue, int minimumCount, string? message = null)
    {
        EnsureNotNullOrWhiteSpace(nameof(parameterName), parameterName);

        EnsureIsGreaterThanOrEqualTo(nameof(minimumCount), minimumCount, 0, $"The minimum count of '{minimumCount}' is less than 0 and invalid.");

        EnsureNotNull(parameterName, parameterValue, message);

        if (parameterValue.Count() < minimumCount)
        {
            throw new ArgumentException(ErrorMessageBuilder.CreateErrorMessage($"A minimum of '{minimumCount}' elements must be present in the collection.", message), parameterName);
        }
    }
}
