using System.Reflection;

namespace Zealot;

public class NumberStrategy : IStrategy
{
    private int _currentNumber = 0;
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        _currentNumber++;
        propertyInfo.SetValue(context.Entity, Convert.ChangeType(_currentNumber, propertyInfo.PropertyType));
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[] { typeof(int), typeof(double), typeof(float), typeof(short) };
}