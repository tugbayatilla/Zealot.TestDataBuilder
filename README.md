# Zealot.SampleBuilder

> Support developers with creating sample data while writing Tests.

## Build

[![.NET](https://github.com/tugbayatilla/Zealot.TestDataBuilder/actions/workflows/dotnet.yml/badge.svg)](https://github.com/tugbayatilla/Zealot.TestDataBuilder/actions/workflows/dotnet.yml)

## Code Quality

[![Qodana](https://github.com/tugbayatilla/Zealot.TestDataBuilder/actions/workflows/code_quality.yml/badge.svg)](https://github.com/tugbayatilla/Zealot.TestDataBuilder/actions/workflows/code_quality.yml)

## How to Use

### Default usage

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .Build();
```

### WithOverride

You can alter or override any value during the process of building.

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithOverride(p => p.YourProperty = YourNewValue)
               .Build();
```

### WithListSize

The lists will have given number of elements in them.

- Default is 2.
- Negative number will be result as zero.
- Supported lists are given below

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithListSize(AnyPossitiveNumber)
               .Build();
```

#### Supported List Types

- ArrayList
- List<>
- IList<>
- ICollection<>
- LinkedList<>
- Queue<>
- Queue
- Stack
- Stack<>
- IEnumerable<>
- IReadOnlyCollection<>
- IReadOnlyList<>

#### Not Supported List Types
              
> They will be null.

- IList
- ICollection
- IEnumerable

### WithStartingNumber

The uniqueness is managed by adding incremental number of the properties.

- String properties have own incremental number
- Number properties have own incremental number
- Number properties are described below.
- You can change the any starting number (positive or negative) 

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithStartingNumber(100)
               .Build();
```

#### Number Properties

- int? 
- int
- short? 
- short
- double? 
- double
- float? 
- float
- decimal? 
- decimal
- long? 
- long
- ushort? 
- ushort
- uint? 
- uint
- ulong? 
- ulong

### WithLogger

You can integrate your ILogger from Microsoft.Extensions.Logging to the builder

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithLogger(Your ILogger interface implementation here)
               .Build();
```


### WithRecursionLevel

You can manipulate the recursion level.

- Default is zero.

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithRecursionLevel(1)
               .Build();
```


### WithStringBody

> You can change default body for all string properties.

- Default is 'test_'.

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithStringBody("suffix")
               .Build();
```

### WithStringUniqueStartingNumber

> You can add incremental number at the end of each string property.

- Default is empty.

```csharp
using Zealot;

var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithStringUniqueStartingNumber(1)
               .Build();
```



### WithDate

> You can change all dates with given datetime.

- Default is DateTime.UtcNow.

```csharp
using Zealot;

var uthNow = DateTime.UtcNow;
var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithDate(utcNow)
               .Build();
```

### WithGuid

> You can change all guids with given datetime.

- Default is Guid.NewGuid().

```csharp
using Zealot;

var guid = Guid.NewGuid();
var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithGuid(guid)
               .Build();
```

### WithDefault

> You can change all properties with default values.

```csharp
using Zealot;

var guid = Guid.NewGuid();
var instance = TestDataBuilder
               .For<Your Class or Struct or any Primitive Type>()
               .WithDefault()
               .Build();
```

