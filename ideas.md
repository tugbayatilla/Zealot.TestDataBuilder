# Ideas

- if there is an attribute of the property, consider it.
- if there is related property name in sub classes. for instance, Address class is a mmber of a person class, and address has PersonId, then Id of the person and the PersonId must be the same.
- Use Strategy pattern
- Every strategy implementation must have context
- context is the current state of the builder
- possible code look alike

```csharp

TestDataBuilder
    .For<TEntity>
    .Build()

```

```csharp
// numbner strategy

public interface IStrategy<TEntity>
{
    // Execute runs according to these types
    IEnumarable<Type> AvailableTypes { get; }
     
    Task ExecuteAsync(
        IContext context, 
        TEntity entity,
        PropertyInfo propertyInfo);  
}

```

```csharp
// future implementation
TestDataBuilder
    .For<TEntity>
    .SetBuildStrategyOnFail(
        - SkipAndContinue: // might return null, default
        - ThrowException   // throws exception directly
    )
    .Build()
```