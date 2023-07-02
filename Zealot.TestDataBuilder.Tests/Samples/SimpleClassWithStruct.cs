namespace Zealot.SampleBuilder.Tests.Samples;

internal class SimpleClassWithStruct
{
    public SimpleStruct SimpleStruct { get; set; }
}

internal struct SimpleStruct
{
    public string StringProp { get; set; }
    public bool BoolProp { get; set; }
}