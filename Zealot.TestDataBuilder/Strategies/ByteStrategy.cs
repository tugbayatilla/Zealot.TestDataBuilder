using System.Reflection;

namespace Zealot.Strategies;

public class ByteStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var value = Convert.ToByte('a');
        
        propertyInfo.SetValue(context.Entity, value);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte)
    };
}
