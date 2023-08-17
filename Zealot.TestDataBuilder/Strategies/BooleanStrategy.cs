using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class BooleanStrategy : IStrategy
{
    public IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(bool),
        typeof(bool?)
    };

    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        return true;
    }
}
