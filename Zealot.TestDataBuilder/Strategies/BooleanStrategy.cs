using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class BooleanStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(bool),
        typeof(bool?)
    };

    public override object Execute(IContext context)
    {
        return true;
    }
}
