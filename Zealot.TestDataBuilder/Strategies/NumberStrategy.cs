using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class NumberStrategy : Strategy
{
    //todo: implement withStartingNumber so numbers can start instead of zero 

    private int _currentNumber;

    public override object GenerateValue(IContext context, Type type)
    {
        if (type.IsNullable())
        {
            var underlyingType = type.GenericTypeArguments.FirstOrDefault();

            var finalExpression = Expression.Constant(Convert.ChangeType(_currentNumber, underlyingType!), type);
            return finalExpression.Value;
        }

        return Convert.ChangeType(_currentNumber, type);
    }

    public override void Execute(IContext context, PropertyInfo propertyInfo)
    {
        _currentNumber++;
        base.Execute(context, propertyInfo);
    }

    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(int?), typeof(int),
            typeof(short?), typeof(short),
            typeof(double?), typeof(double),
            typeof(float?), typeof(float),
            typeof(decimal?), typeof(decimal),
            typeof(long?), typeof(long),
            typeof(UInt16?), typeof(UInt16),
            typeof(UInt32?), typeof(UInt32),
            typeof(UInt64?), typeof(UInt64)
        };
}