using System.Reflection;

namespace Zealot.Strategies;

public class CharStrategy : Strategy
{
    private const char A = 'A';

    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, A);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(char?), typeof(char)
        };
}
