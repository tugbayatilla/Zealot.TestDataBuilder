using System.Diagnostics.CodeAnalysis;

namespace Zealot;

public static class TestDataBuilder
{
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        var entity = new TEntity();
        
        IContext context = new Context(entity);
        IStrategyContainer strategyContainer = new StrategyContainer();
        
        var builder = new Builder<TEntity>(context, strategyContainer);
        return builder;
    }
}

public class Context : IContext
{
    public Context(object entity)
    {
        Entity = entity;
    }

    public object Entity { get; }
}