using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class BooleanStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(bool),
        typeof(bool?)
    };

    public override object GenerateValue(IContext context, Type type)
    {
        return true;
    }
}
