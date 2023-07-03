using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class DatetimeStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };

    public override object GenerateValue(IContext context, Type type)
    {
        return context.WithUtcDate;
    }
}
