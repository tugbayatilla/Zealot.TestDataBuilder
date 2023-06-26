namespace Zealot;

public sealed class SampleBuilder<T> where T: class, new()
{
    public static T Build()
    {
        return new T();
    }
}