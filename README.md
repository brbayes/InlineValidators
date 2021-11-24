# Inline Validators
[![Build Library](https://github.com/brbayes/InlineValidators/actions/workflows/build.workflow.yml/badge.svg)](https://github.com/brbayes/InlineValidators/actions/workflows/build.workflow.yml)

Welcome to the Inline Validators library! This library is designed to simplify the validation of arguments and parameters by simplifying each validation down to a single line.

## Examples
The Inline Validation library can be used by calling the static class `IV` in the `InlineValidators` namespace. Any values that fail validation will cause the called method to throw an exception. The exception will vary depending on the validation, though `ArgumentException`, `ArgumentNullException`, and `ArgumentOutOfRangeException` are the exceptions commonly thrown.

``` csharp
using InlineValidators;

public MyClass
{
    private readonly string _myField;

    public MyClass(string argument1)
    {
        _myField = IV.EnsureNotNull(nameof(argument1), argument1);
    }
}
```

The Inline Validation library also supports nullables and custom messages.
``` csharp
using InlineValidators;

public MyClass
{
    private readonly string _myField1;
    private readonly string _myField2;

    public MyClass(string? argument1, string argument2)
    {
        // Check a nullable field, and return a non-nullable value.
        _myField1 = IV.EnsureNotNull(nameof(argument1), argument1);

        // Add a custom message to the exception.
        _myField2 = IV.EnsureNotNullOrWhiteSpace(nameof(argument2), argument2, "argument1 can not be null, empty, or whitespace.");
    }
}
```

There are also a variety of additional validators included in the library, ranging from numbers, to strings, enums, and lists.
``` csharp
// General Validators
var obj1 = new Object();
IV.EnsureNotNull(nameof(obj1), obj1);

// String Validators
var string1 = "my string";
IV.EnsureNotNullOrEmpty(nameof(string1), string1);
IV.EnsureNotNullOrWhiteSpace(nameof(string1), string1);

// Number Validators
var num1 = 5;
IV.EnsureIsGreaterThan(nameof(num1), num1, 2);
IV.EnsureIsGreaterThanOrEqualTo(nameof(num1), num1, 5);
IV.EnsureIsLessThan(nameof(num1), num1, 10);
IV.EnsureIsLessThanOrEqualTo(nameof(num1), num1, 6);

// Enum Validators
public enum TestEnum
{
    Option1,
    Option2,
}

var enumValue1 = TestEnum.Option2;

IV.EnsureIsValidEnum(nameof(enumValue1), enumValue1);
IV.EnsureIsValidEnumAndNotDefault(nameof(enumValue1), enumValue1);

// List Validators
var list1 = new List<bool> { true, false };
IV.EnsureNotNullOrEmpty(nameof(list1), list1);
IV.EnsureHasMinimumCount(nameof(list1), list1, 2);
```

## Contributing
This library is still in its early stages, and only includes a limited set of validators. If you find that the library does not have all of what you need, feel free to raise a pull request to add it in.
