using System.Reflection;

namespace Zealot;

public class NumberStrategy<TEntity> : IStrategy<TEntity> 
{
    public async Task ExecuteAsync(IContext context, TEntity entity, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(entity, 1);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[] { typeof(int) };
}