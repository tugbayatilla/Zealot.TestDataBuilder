using System.Collections;
using System.Reflection;

namespace Zealot.Strategies;

public class DictionaryStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var ins = Instance.Create(propertyInfo.PropertyType);
        propertyInfo.SetValue(context.Entity, ins); 

        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[] {
            typeof(Dictionary<,>)
        };
}