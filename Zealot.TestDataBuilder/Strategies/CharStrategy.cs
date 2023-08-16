using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class CharStrategy : Strategy
{
    private const char A = 'A';

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(char?), typeof(char)
    };

    public override object ExecuteWithReturn(IContext context)
    {
        return A;
    }
}
