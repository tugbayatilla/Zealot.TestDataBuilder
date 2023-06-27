using System.Reflection;

namespace Zealot.Strategies;

public class CharStrategy : IStrategy
{
    private const char A = 'A';

    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, A);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(char?), typeof(char)
        };
}