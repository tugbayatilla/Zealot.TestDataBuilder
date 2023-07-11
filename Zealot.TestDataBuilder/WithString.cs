using Zealot.Interfaces;

namespace Zealot;

internal class WithString : IWithString
{
    public string Prefix { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;
}