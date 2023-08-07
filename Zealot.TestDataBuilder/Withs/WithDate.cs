using Zealot.Interfaces;

namespace Zealot.Withs;

internal class WithDate : IWithDate
{
    public DateTime UtcDate { get; set; } = DateTime.UtcNow;
}
