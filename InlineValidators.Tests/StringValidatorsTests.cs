using System;
using Xunit;

namespace InlineValidators.Tests;

public class StringValidatorsTests
{
    private const string ParameterName = "parameter1";
    private const string ParameterValue = "value1";
    private const string CustomErrorMessage = "A custom error message goes here.";

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
    [InlineData("")]
    public void EnsureNotNullOrEmpty_ThrowsForNullValues(string? parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrEmpty(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("Parameter can not be null or empty.", exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrEmpty_IncludesCustomMessage()
    {
        var exception = Assert.ThrowsAny<ArgumentNullException>(() => IV.EnsureNotNullOrEmpty(ParameterName, null, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrEmpty_ReturnsNotNullValue()
    {
        string? testValue = ParameterValue;
        var returnedValue = IV.EnsureNotNullOrEmpty(ParameterName, testValue);
        Assert.Equal(ParameterValue, returnedValue);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureNotNullOrWhiteSpace_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrWhiteSpace(parameterName, ParameterValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void EnsureNotNullOrWhiteSpace_ThrowsForNullValues(string? parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNullOrWhiteSpace(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("Parameter can not be null, empty, or contain only whitespace characters.", exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrWhiteSpace_IncludesCustomMessage()
    {
        var exception = Assert.ThrowsAny<ArgumentNullException>(() => IV.EnsureNotNullOrWhiteSpace(ParameterName, null, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureNotNullOrWhiteSpace_ReturnsNotNullValue()
    {
        string? testValue = ParameterValue;
        var returnedValue = IV.EnsureNotNullOrWhiteSpace(ParameterName, testValue);
        Assert.Equal(ParameterValue, returnedValue);
    }
}
