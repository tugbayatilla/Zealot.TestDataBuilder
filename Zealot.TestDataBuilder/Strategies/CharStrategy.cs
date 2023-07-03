using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class CharStrategy : Strategy
{
    private const char A = 'A';

    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, A);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(char?), typeof(char)
    };
}