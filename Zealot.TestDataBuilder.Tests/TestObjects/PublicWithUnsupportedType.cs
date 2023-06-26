namespace Zealot.SampleBuilder.Tests.TestObjects;

public class PublicWithUnsupportedType
{
    public struct UnsupportedType {}

    public UnsupportedType UnsupportedTypeProp { get; set; }
}