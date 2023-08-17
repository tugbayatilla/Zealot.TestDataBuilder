using System.Linq.Expressions;

namespace Zealot.Interfaces;

public interface IStrategy
{
    IEnumerable<Type> AvailableTypes { get; }
    Expression<Func<Type, bool>> ResolveCondition { get; }
    object Execute(IContext context);
}
