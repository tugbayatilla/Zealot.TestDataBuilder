using System.Reflection;

namespace Zealot;

public class NumberStrategy<TEntity> : IStrategy<TEntity>
{
    private int _currentNumber = 0;
    public async Task ExecuteAsync(IContext context, TEntity entity, PropertyInfo propertyInfo)
    {
        _currentNumber++;
        propertyInfo.SetValue(entity, _currentNumber);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[] { typeof(int) };
}