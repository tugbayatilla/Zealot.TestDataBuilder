namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class ClassWithOnePropertyWithoutSetter
{
    public int IntProperty { get; set; }
    public string StringProperty { get; set; }
    public string NoSetterProperty { get; }
}
