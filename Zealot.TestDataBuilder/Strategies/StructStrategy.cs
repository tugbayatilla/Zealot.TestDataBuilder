using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

internal class StructStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var instance = Instance.Create(propertyInfo.PropertyType);
        
        var newInstance = instance.WithContext(context).Build();
        
        propertyInfo.SetValue(context.Entity, newInstance);

        await Task.CompletedTask;
    }

    public override Expression<Func<PropertyInfo, bool>> ResolveCondition => info => info.PropertyType.IsStruct();
}
