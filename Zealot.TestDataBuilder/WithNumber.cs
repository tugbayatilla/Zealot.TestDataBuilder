using Zealot.Interfaces;

namespace Zealot;

internal class WithNumber : IWithNumber
{
    public int StartingNumber { get; set; } = 1;
}