using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class DatetimeStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, context.WithUtcDate);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };
}
