using System.Reflection;

namespace Zealot.Strategies;

internal class GuidStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, context.WithGuid);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(Guid),
    };
}
