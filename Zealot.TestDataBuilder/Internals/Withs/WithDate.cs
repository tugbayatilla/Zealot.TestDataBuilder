using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Withs;

internal class WithDate : IWithDate
{
    public DateTime UtcDate { get; set; } = DateTime.UtcNow;
}
