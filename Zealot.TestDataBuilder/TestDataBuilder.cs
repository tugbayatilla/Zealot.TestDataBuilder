namespace Zealot;

public sealed class TestDataBuilder<T> where T: class, new()
{
    public static T Build()
    {
        return new T();
    }
}