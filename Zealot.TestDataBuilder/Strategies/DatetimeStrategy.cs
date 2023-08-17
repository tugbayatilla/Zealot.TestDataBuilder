using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class DatetimeStrategy : IStrategy
{
    public IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };

    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        return context.With.Date.UtcDate;
    }
}
