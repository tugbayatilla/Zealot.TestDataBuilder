using System.Linq.Expressions;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Strategies;

internal class BooleanStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object? Execute(IContext context)
    {
        return true;
    }
    
    private static IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(bool),
        typeof(bool?)
    };
}
