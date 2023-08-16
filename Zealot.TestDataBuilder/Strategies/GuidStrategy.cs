using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class GuidStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(Guid?),typeof(Guid),
    };

    public override object ExecuteWithReturn(IContext context)
    {
        return context.With.Guid.Guid;
    }
}
