// ReSharper disable All
namespace Zealot.Tests.TestObjects;

internal class ClassWithEquality
{
    public int IntValue { get; set; }

    public override bool Equals(object? obj)
    {
        return IntValue == (obj as ClassWithEquality)?.IntValue;
    }

    public override int GetHashCode()
    {
        return IntValue.GetHashCode();
    }
}
