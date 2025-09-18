# DotNetExtensions

This is a collection of extension methods for .NET Core.
The goal is to provide a set of useful extension methods that are not included in the .NET Core framework.

[![.NET](https://github.com/Necas209/DotNetExtensions/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Necas209/DotNetExtensions/actions/workflows/dotnet.yml)
[![CodeQL Advanced](https://github.com/Necas209/DotNetExtensions/actions/workflows/codeql.yml/badge.svg)](https://github.com/Necas209/DotNetExtensions/actions/workflows/codeql.yml)

## Installation

You can install the package via NuGet:

```bash
dotnet add package DotNetExtensions
```

## Usage

```csharp
using DotNetExtensions.Core;

public class Example
{
    public void ExampleMethod()
    {
        var myNumber = 12345;
        var numberOfDigits = myNumber.NumberOfDigits(); // numberOfDigits = 5
    }
}
```
