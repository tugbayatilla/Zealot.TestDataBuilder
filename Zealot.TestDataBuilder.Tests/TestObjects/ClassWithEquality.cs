namespace Zealot.SampleBuilder.Tests.TestObjects;

// ReSharper disable once ClassNeverInstantiated.Global
internal class ClassWithEquality
{
    public int IntValue { get; set; }

    public override bool Equals(object obj)
    {
        return IntValue == (obj as ClassWithEquality)?.IntValue;
    }

    protected bool Equals(ClassWithEquality other)
    {
        return IntValue == other.IntValue;
    }

    public override int GetHashCode()
    {
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        return IntValue.GetHashCode();
    }
}
