namespace Zealot.Tests.TestObjects;

public class ClassWithTwoStringInConstructor
{
    public ClassWithTwoStringInConstructor(string first, string second)
    {
        Prop1 = first;
        Prop2 = second;
    }

    public string Prop1 { get; }
    public string Prop2 { get; }
}
