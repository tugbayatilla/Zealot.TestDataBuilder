using System.Reflection;

namespace Zealot.Strategies;

public class CharStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        const char a = 'a';

        propertyInfo.SetValue(context.Entity, a);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(char?), typeof(char)
        };
}