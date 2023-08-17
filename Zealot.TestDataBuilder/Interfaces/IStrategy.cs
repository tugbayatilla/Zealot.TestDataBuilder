using System.Linq.Expressions;

namespace Zealot.Interfaces;

public interface IStrategy
{
    Expression<Func<Type, bool>> ResolveCondition { get; }
    object Execute(IContext context);
}
