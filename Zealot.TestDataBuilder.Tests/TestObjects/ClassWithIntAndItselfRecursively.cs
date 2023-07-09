namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class ClassWithIntAndItselfRecursively
{
    public int IntProp { get; set; }
    public ClassWithIntAndItselfRecursively Prop { get; set; }
}
