using System;
using Xunit;

namespace InlineValidators.Tests;
public class EnumValidatorsTests
{
    private const string ParameterName = "parameter1";
    private const TestEnum ParameterValue = TestEnum.Value1;
    private const TestEnum BadParameterValue = (TestEnum)100;
    private const string CustomErrorMessage = "A custom error message goes here.";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureIsValidEnum_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureIsValidEnum(parameterName, ParameterValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Theory]
    [InlineData((TestEnum)(-1))]
    [InlineData((TestEnum)100)]
    public void EnsureIsValidEnum_ThrowsForInvalidValues(TestEnum parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureIsValidEnum(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("The parameter value is not valid for the enum.", exception.Message);
    }

    [Fact]
    public void EnsureIsValidEnum_IncludesCustomMessage()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => IV.EnsureIsValidEnum(ParameterName, BadParameterValue, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureIsValidEnum_ReturnsValue()
    {
        var returnedValue = IV.EnsureIsValidEnum(ParameterName, ParameterValue);
        Assert.Equal(ParameterValue, returnedValue);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("\t")]
    public void EnsureIsValidEnumAndNotDefault_ValidatesParameterName(string parameterName)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureIsValidEnumAndNotDefault(parameterName, ParameterValue));
        Assert.Equal("parameterName", exception.ParamName);
    }

    [Theory]
    [InlineData((TestEnum)(-1))]
    [InlineData((TestEnum)100)]
    public void EnsureIsValidEnumAndNotDefault_ThrowsForInvalidValues(TestEnum parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureIsValidEnumAndNotDefault(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("The parameter value is not valid for the enum.", exception.Message);
    }

    [Theory]
    [InlineData(default(TestEnum))]
    public void EnsureIsValidEnumAndNotDefault_ThrowsForDefaultValue(TestEnum parameterValue)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() => IV.EnsureIsValidEnumAndNotDefault(ParameterName, parameterValue));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith("The parameter value cannot be the default enum value.", exception.Message);
    }

    [Fact]
    public void EnsureIsValidEnumAndNotDefault_IncludesCustomMessage()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => IV.EnsureIsValidEnumAndNotDefault(ParameterName, BadParameterValue, CustomErrorMessage));
        Assert.Equal(ParameterName, exception.ParamName);
        Assert.StartsWith(CustomErrorMessage, exception.Message);
    }

    [Fact]
    public void EnsureIsValidEnumAndNotDefault_ReturnsValue()
    {
        var returnedValue = IV.EnsureIsValidEnumAndNotDefault(ParameterName, ParameterValue);
        Assert.Equal(ParameterValue, returnedValue);
    }

    public enum TestEnum
    {
        DefaultValue,
        Value1,
    }
}
