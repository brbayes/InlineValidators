using System;
using Xunit;

namespace InlineValidators.Tests;

public class GenericValidatorsTests
{
    private const string ParameterName = "parameter1";
    private const string ParameterRefValue = "value1";
    private const bool ParameterStructValue = true;
    private const string CustomErrorMessage = "A custom error message goes here.";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureNotNull_RefType_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNull<string>(parameterName, ParameterRefValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Fact]
    public void EnsureNotNull_RefType_ThrowsForNullValues()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => IV.EnsureNotNull<string>(ParameterName, null));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith($"Parameter can not be null.", exception.Message);
    }

    [Fact]
    public void EnsureNotNull_RefType_IncludesCustomMessage()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => IV.EnsureNotNull<string>(ParameterName, null, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureNotNull_RefType_ReturnsNotNullValue()
    {
        string? testValue = ParameterRefValue;
        var returnedValue = IV.EnsureNotNull(ParameterName, testValue);
        Assert.Equal(ParameterRefValue, returnedValue);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureNotNull_StructType_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureNotNull<bool>(parameterName, ParameterStructValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Fact]
    public void EnsureNotNull_StructType_ThrowsForNullValues()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => IV.EnsureNotNull<bool>(ParameterName, null));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith($"Parameter can not be null.", exception.Message);
    }

    [Fact]
    public void EnsureNotNull_StructType_IncludesCustomMessage()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => IV.EnsureNotNull<bool>(ParameterName, null, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureNotNull_StructType_ReturnsNotNullValue()
    {
        bool? testValue = true;
        var returnedValue = IV.EnsureNotNull(ParameterName, testValue);
        Assert.True(returnedValue);
    }
}