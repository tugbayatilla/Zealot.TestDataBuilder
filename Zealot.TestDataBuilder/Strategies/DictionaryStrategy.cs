using System.Reflection;

namespace Zealot.Strategies;

public class DictionaryStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
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

    public IEnumerable<Type> AvailableTypes =>
        new[] {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };
}