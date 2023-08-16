using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal abstract class Strategy : IStrategy
{
    public virtual IEnumerable<Type> AvailableTypes { get; } = default!;
    public virtual Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public abstract object ExecuteWithReturn(IContext context);
}
