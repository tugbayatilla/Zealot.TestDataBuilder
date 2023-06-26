namespace Zealot;

public sealed class TestDataBuilder
{
    public static IBuilder<TEntity> For<TEntity>() 
        where TEntity: new()
    {
        var builder = new Builder<TEntity>();
        return builder;
    }
}

public class Builder<TEntity> : IBuilder<TEntity> 
    where TEntity: new()
{
    public TEntity Build()
    {
        return new TEntity();
    }
}