namespace Zealot.Tests.TestObjects;

internal class StructWithIntAndItselfRecursively
{
    public int IntProp { get; set; }
    public StructWithIntAndItselfRecursively Prop { get; set; }
}
