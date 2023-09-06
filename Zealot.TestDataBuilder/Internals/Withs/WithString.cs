namespace Zealot.Internals.Withs;

internal class WithString : IWithString
{
    public string Body { get; set; } = TestDataBuilder.DefaultStringBodyTemplate;
    public int StringUniqueStartingNumber { get; set; } = 1;
}
