using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class DatetimeStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };

    public override object Execute(IContext context)
    {
        return context.With.Date.UtcDate;
    }
}
