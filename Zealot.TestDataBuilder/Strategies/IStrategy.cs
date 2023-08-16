using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

public interface IStrategy
{
    IEnumerable<Type> AvailableTypes { get; }
    Expression<Func<Type, bool>> ResolveCondition { get; }
    object ExecuteWithReturn(IContext context);
}
