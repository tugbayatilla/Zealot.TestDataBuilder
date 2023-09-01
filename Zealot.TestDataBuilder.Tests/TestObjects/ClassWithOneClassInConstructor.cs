namespace Zealot.Tests.TestObjects;

internal class ClassWithOneClassInConstructor
{
    public ClassWithOneClassInConstructor(ClassWithTwoString argument)
    {
        Prop1 = argument.Prop1;
        Prop2 = argument.Prop2;
    }
    public string Prop1 { get; }
    public string Prop2 { get; }
}
