namespace Zealot.Tests.TestObjects;

internal class ClassWithOneDateTimeInConstructor
{
    public ClassWithOneDateTimeInConstructor(DateTime dateTime)
    {
        Prop = dateTime;
    }

    public DateTime Prop { get; }
}
