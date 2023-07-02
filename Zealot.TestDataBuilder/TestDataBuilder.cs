namespace Zealot;

public static class TestDataBuilder
{
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        IContext context = new Context(
            new TEntity(), 
            new WithOnlyContainer(),
            new StrategyContainer());

        return new Builder<TEntity>(context);
    }
    
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> WithContext<TEntity>(this TEntity entity, IContext context)
        where TEntity : new()
    {
        var newContext = context.CloneWithNew(entity);
        
        return new Builder<TEntity>(newContext);
    }
    
}