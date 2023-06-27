using System.Reflection;

namespace Zealot.Strategies;

public class ByteStrategy : IStrategy
{
    private static readonly byte A = Convert.ToByte('A');

    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, A);
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte?), typeof(byte)
    };
}
