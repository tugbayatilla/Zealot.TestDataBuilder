namespace Zealot;

public static class TestDataBuilder
{
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        IContext context = new Context(
            new TEntity(), 
            new SetOnlyTypeContainer());

        return new Builder<TEntity>(context, new StrategyContainer());
    }
}