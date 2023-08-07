namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class ClassWithSelfListRecursively
{
    public ClassWithSelfListRecursively Self { get; set; }
    public List<ClassWithSelfListRecursively> SelfList { get; set; }

}