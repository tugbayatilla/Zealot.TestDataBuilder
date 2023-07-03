using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

internal class ArrayStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var listType = propertyInfo.PropertyType;

        if (propertyInfo.PropertyType is {IsInterface: true, IsGenericType: true})
        {
            listType = typeof(List<>).MakeGenericType(propertyInfo.PropertyType.GenericTypeArguments);
        }

        var listInstance = Instance.Create(listType);
        propertyInfo.SetValue(context.Entity, listInstance);

        await Task.CompletedTask;
    }
    
    public override Expression<Func<PropertyInfo, bool>> ResolveCondition => info => info.PropertyType.IsArray;
}
