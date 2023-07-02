using System.Reflection;

namespace Zealot.Strategies;

internal class StringStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, propertyInfo.Name);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[] { typeof(string) };
}
