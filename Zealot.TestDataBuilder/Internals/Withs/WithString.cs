namespace Zealot.Internals.Withs;

internal class WithString : IWithString
{
    public SetValue<string> Body { get; set; } = new();
    public SetValue<int> StringUniqueStartingNumber { get; set; } = new(1);
}
