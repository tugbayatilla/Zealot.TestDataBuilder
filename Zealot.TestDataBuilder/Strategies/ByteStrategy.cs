using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class ByteStrategy : Strategy
{
    private static readonly byte A = Convert.ToByte('A');

    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(byte?), typeof(byte)
    };

    public override object Execute(IContext context)
    {
        return A;
    }
}
