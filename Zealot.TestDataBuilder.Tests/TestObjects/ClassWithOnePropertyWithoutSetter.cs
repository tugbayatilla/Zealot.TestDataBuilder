namespace Zealot.Tests.TestObjects;

internal class ClassWithOnePropertyWithoutSetter
{
    public int IntProp { get; set; }
    public string StringProp { get; set; }
    public string NoSetterProp { get; }
}
