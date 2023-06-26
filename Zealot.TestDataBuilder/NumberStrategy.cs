using System.Linq.Expressions;
using System.Reflection;

namespace Zealot;

public class NumberStrategy : IStrategy
{
    private int _currentNumber = 0;

    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        _currentNumber++;

        if (IsNullableType(propertyInfo.PropertyType))
        {
            var finalExpression = Expression.Constant(_currentNumber++, propertyInfo.PropertyType);
            propertyInfo.SetValue(context.Entity, finalExpression.Value);
        }
        else
        {
            propertyInfo.SetValue(context.Entity, Convert.ChangeType(_currentNumber, propertyInfo.PropertyType));
        }

        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[] {typeof(int?), typeof(int), typeof(double), typeof(float), typeof(short)};

    static bool IsNullableType(Type type)
    {
        // ref-type
        if (!type.IsValueType)
        {
            return true; 
        }

        // Nullable<T>
        return Nullable.GetUnderlyingType(type) != null;
    }
}