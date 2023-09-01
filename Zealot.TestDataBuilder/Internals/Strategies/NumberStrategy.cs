namespace Zealot.Internals.Strategies;

internal class NumberStrategy : IStrategy
{
    private int _currentNumber;

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x == info);

    public object Execute(IContext context)
    {
        var type = FindType(context);

        SetStartingNumberAtTheBeginning(context);

        var nextNumber = Convert.ChangeType(_currentNumber++, type);
        
        return type.IsNullable() 
            ? Expression.Constant(nextNumber, type).Value! 
            : nextNumber;
    }

    private static Type FindType(IContext context)
    {
        var type = context.Scope.EntityType;
        if (type.IsNullable()) type = type.GenericTypeArguments.FirstOrDefault();
        return type!;
    }

    private void SetStartingNumberAtTheBeginning(IContext context)
    {
        if (_currentNumber == default)
        {
            _currentNumber = context.With.Number.StartingNumber;
        }
    }

    private static IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(int?), typeof(int),
            typeof(short?), typeof(short),
            typeof(double?), typeof(double),
            typeof(float?), typeof(float),
            typeof(decimal?), typeof(decimal),
            typeof(long?), typeof(long),
            typeof(ushort?), typeof(ushort),
            typeof(uint?), typeof(uint),
            typeof(ulong?), typeof(ulong)
        };
}
