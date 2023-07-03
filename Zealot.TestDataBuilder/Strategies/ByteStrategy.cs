using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class ByteStrategy : Strategy
{
    private static readonly byte A = Convert.ToByte('A');

    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, A);
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte?), typeof(byte)
    };
}
