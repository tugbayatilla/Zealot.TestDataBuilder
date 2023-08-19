using System.Linq.Expressions;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Strategies;

internal class CharStrategy : IStrategy
{
    private const char A = 'A';
    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        return A;
    }
    private static IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(char?), typeof(char)
    };
}
