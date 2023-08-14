namespace Zealot.SampleBuilder.Tests.TestObjects;

internal abstract class ClassWithPrivateConstructor
{
    public static ClassWithPrivateConstructor Init() => null!;
    private ClassWithPrivateConstructor()
    {
    }
}
