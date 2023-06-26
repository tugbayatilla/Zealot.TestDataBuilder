namespace Zealot;

public sealed class TestDataBuilder : IBuilder
{
    public static IBuilder For<T>()
    {
        var builder = new Builder<T>();
        return builder;
    }
}

public class Builder<T> : IBuilder
{
    
}