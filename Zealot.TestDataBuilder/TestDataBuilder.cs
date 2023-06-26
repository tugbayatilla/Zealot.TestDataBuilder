namespace Zealot;

public static class TestDataBuilder
{
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        IContext context = default!;
        var builder = new Builder<TEntity>(context);
        return builder;
    }
}