using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot;

public static class TestDataBuilder
{
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : class, new()
    {
        IContext context = new Context(
            new TEntity(), 
            new WithOnly(),
            new StrategyContainer(),
            new WithRecursionLevel());

        return new Builder<TEntity>(context);
    }
    
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> WithContext<TEntity>(this TEntity entity, IContext context)
        where TEntity : class, new()
    {
        var newContext = context.CloneWithNew(entity);
        
        return new Builder<TEntity>(newContext);
    }
    
}