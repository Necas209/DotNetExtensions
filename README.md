# DotNetExtensions

This is a collection of extension methods for .NET Core.
The goal is to provide a set of useful extension methods that are not included in the .NET Core framework.

## Installation

You can install the package via NuGet:

```bash
dotnet add package DotNetExtensions
```

## Usage

```csharp
using DotNetExtensions;

public class Example
{
    public void ExampleMethod()
    {
        var myNumber = 12345;
        var numberOfDigits = myNumber.NumberOfDigits(); // numberOfDigits = 5
    }
}
```