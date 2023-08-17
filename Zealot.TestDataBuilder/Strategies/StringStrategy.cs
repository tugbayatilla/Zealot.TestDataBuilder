using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class StringStrategy : IStrategy
{
    private int _number;
    public IEnumerable<Type> AvailableTypes => new[] { typeof(string) };
    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        _number++;
        return $"{context.With.String.Prefix}{context.Scope.PropertyName}_{_number}{context.With.String.Suffix}";
    }
}
