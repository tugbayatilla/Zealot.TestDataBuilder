using System.Linq.Expressions;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Strategies;

internal class ByteStrategy : IStrategy
{
    private static readonly byte A = Convert.ToByte('A');

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x=>x == info);

    public object? Execute(IContext context)
    {
        return A;
    }
    
    private static IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte?), typeof(byte)
    };
}
