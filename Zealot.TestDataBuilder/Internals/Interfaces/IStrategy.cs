using System.Linq.Expressions;

namespace Zealot.Internals.Interfaces;

internal interface IStrategy
{
    Expression<Func<Type, bool>> ResolveCondition { get; }
    object Execute(IContext context);
}
