namespace Zealot.SampleBuilder.Tests.TestObjects;

public class RecursiveItselfStruct
{
    public int IntProp { get; set; }
    public RecursiveItselfStruct RecursiveItselfProp { get; set; }
}