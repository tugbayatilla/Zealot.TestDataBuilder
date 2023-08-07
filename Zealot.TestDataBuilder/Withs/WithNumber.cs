using Zealot.Interfaces;

namespace Zealot.Withs;

internal class WithNumber : IWithNumber
{
    public int StartingNumber { get; set; } = 1;
}
