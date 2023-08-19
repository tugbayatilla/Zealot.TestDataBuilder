using System.Linq.Expressions;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Strategies;

internal class NumberStrategy : IStrategy
{
    private int _currentNumber;

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x == info);

    public object Execute(IContext context)
    {
        var type = context.Scope.EntityType;

        SetStartingNumberAtTheBeginning(context);

        if (!type.IsNullable()) return Convert.ChangeType(_currentNumber++, type);
        
        var underlyingType = type.GenericTypeArguments.FirstOrDefault();

        var finalExpression = Expression.Constant(Convert.ChangeType(_currentNumber++, underlyingType!), type);
        return finalExpression.Value;

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
