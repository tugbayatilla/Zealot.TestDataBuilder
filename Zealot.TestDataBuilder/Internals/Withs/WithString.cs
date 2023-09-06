namespace Zealot.Internals.Withs;

internal class WithString : IWithString
{
    public string Prefix { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;
    public StringBody Body { get; set; } = new();
}
