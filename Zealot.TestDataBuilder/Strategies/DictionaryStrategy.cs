using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class DictionaryStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var propertyType = propertyInfo.PropertyType;

        if (propertyInfo.PropertyType is {IsInterface: true, IsGenericType: true})
        {
            propertyType = typeof(Dictionary<,>).MakeGenericType(propertyInfo.PropertyType.GenericTypeArguments);
        }

        var listInstance = Instance.Create(propertyType);
        propertyInfo.SetValue(context.Entity, listInstance);

        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes =>
        new[] {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };
    
    public override Expression<Func<PropertyInfo, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x.Name == info.PropertyType.Name);
}
