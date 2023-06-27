using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

public class NumberStrategy : IStrategy
{
    private int _currentNumber = 0;

    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        _currentNumber++;

        if (propertyInfo.IsNullable())
        {
            var underlyingType = propertyInfo.PropertyType.GenericTypeArguments.FirstOrDefault();

            var finalExpression = Expression.Constant(
                Convert.ChangeType(_currentNumber, underlyingType!), 
                propertyInfo.PropertyType);
            propertyInfo.SetValue(context.Entity, finalExpression.Value);
        }
        else
        {
            propertyInfo.SetValue(context.Entity, Convert.ChangeType(_currentNumber, propertyInfo.PropertyType));
        }

        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[] {
            typeof(int?), typeof(int),
            typeof(short?), typeof(short),
            typeof(double?), typeof(double), 
            typeof(float?), typeof(float),
            typeof(decimal?), typeof(decimal),
            typeof(long?), typeof(long)
        };
}