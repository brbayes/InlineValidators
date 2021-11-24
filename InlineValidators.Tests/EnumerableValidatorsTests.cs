using System;
using System.Collections.Generic;
using Xunit;

namespace InlineValidators.Tests;

public class EnumerableValidatorsTests
{
    private const string ParameterName = "parameter1";
    private const int MinimumCount = 3;
    private static readonly IEnumerable<bool> ParameterValue = new List<bool> { true, false, true };
    private const string CustomErrorMessage = "A custom error message goes here.";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureHasMinimumCount_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureHasMinimumCount(parameterName, ParameterValue, MinimumCount));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    public void EnsureHasMinimumCount_ThrowsForNullValues(IEnumerable<bool> parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureHasMinimumCount(ParameterName, parameterValue, MinimumCount));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("Parameter can not be null.", exception.Message);
    }

    [Fact]
    public void EnsureHasMinimumCount_ThrowsForCollectionsWithNotEnoughElements()
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureHasMinimumCount(ParameterName, new List<bool> { true }, MinimumCount));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith($"A minimum of '{MinimumCount}' elements must be present in the collection.", exception.Message);
    }

    [Fact]
    public void EnsureHasMinimumCount_ThrowsForInvalidMinimumCount()
    {
        var minimumCount = -1;
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => IV.EnsureHasMinimumCount(ParameterName, ParameterValue, minimumCount));
        Assert.Equal("minimumCount", exception.ParamName);
        Assert.StartsWith($"The minimum count of '{minimumCount}' is less than 0 and invalid.", exception.Message);
    }

    [Fact]
    public void EnsureHasMinimumCount_IncludesCustomMessage()
    {
        var exception = Assert.ThrowsAny<ArgumentNullException>(() => IV.EnsureHasMinimumCount<bool>(ParameterName, null, MinimumCount, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureHasMinimumCount_DoesNotThrowForValidCollection()
    {
        IV.EnsureHasMinimumCount(ParameterName, ParameterValue, MinimumCount);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureNotNullOrEmpty_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrEmpty(parameterName, ParameterValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    public void EnsureNotNullOrEmpty_ThrowsForNullValues(IEnumerable<bool> parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrEmpty(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("Parameter can not be null.", exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrEmpty_ThrowsForCollectionsWithNotEnoughElements()
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrEmpty(ParameterName, new List<bool>()));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("A minimum of '1' elements must be present in the collection.", exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrEmpty_IncludesCustomMessage()
    {
        var exception = Assert.ThrowsAny<ArgumentNullException>(() => IV.EnsureNotNullOrEmpty<bool>(ParameterName, null, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrEmpty_DoesNotThrowForValidCollection()
    {
        IV.EnsureNotNullOrEmpty(ParameterName, ParameterValue);
    }
}
