using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class ByteStrategy : IStrategy
{
    private static readonly byte A = Convert.ToByte('A');

    public IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte?), typeof(byte)
    };

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        return A;
    }
}
