using Zealot.Interfaces;

namespace Zealot;

internal class WithDate : IWithDate
{
    public DateTime UtcDate { get; set; } = DateTime.UtcNow;
}