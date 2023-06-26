using System.Reflection;

namespace Zealot;

public class StringStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, propertyInfo.Name);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[] { typeof(string) };
}
