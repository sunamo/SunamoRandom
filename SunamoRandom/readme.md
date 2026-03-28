# SunamoRandom

A lightweight .NET library for generating random values of various types including integers, floats, bytes, strings, booleans, DateTimes, and enum values.

## Installation

```bash
dotnet add package SunamoRandom
```

## Features

- **Random integers** with inclusive/exclusive bounds (`RandomInt`, `RandomInt2`)
- **Random floats** with configurable decimal precision (`RandomFloat`)
- **Random bytes** and byte arrays (`RandomByte`, `RandomBytes`)
- **Random strings** with control over character types: uppercase, lowercase, numeric, special (`RandomString`, `RandomStringWithoutSpecial`)
- **Random booleans** (`RandomBool`)
- **Random DateTimes** up to a specified year (`RandomDateTime`)
- **Random enum values** (`RandomEnum<T>`)
- **Random collection elements** (`RandomElementOfCollectionT<T>`, `RandomElementOfCollection`)
- **Random color components** for light/dark palettes (`RandomColorPart`)
- **Random number lists** (`RandomHelperList.GenerateNumbers`)
- **Password-style strings** with non-alphanumeric characters (`RandomStringHelper.RandomString`)

## Usage

```csharp
using SunamoRandom;

// Random integer between 1 and 100 (inclusive)
int number = RandomHelper.RandomInt(1, 100);

// Random string of 10 alphanumeric characters
string text = RandomHelper.RandomStringWithoutSpecial(11);

// Random enum value
MyEnum value = RandomHelper.RandomEnum<MyEnum>();

// Random element from a list
var element = RandomHelper.RandomElementOfCollectionT(myList);

// Generate a list of 5 random 6-digit numbers
var numbers = RandomHelperList.GenerateNumbers(6, 5);
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## License

MIT
