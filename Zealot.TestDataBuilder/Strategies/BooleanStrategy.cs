using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class BooleanStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, false);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(bool),
        typeof(bool?)
    };
}
