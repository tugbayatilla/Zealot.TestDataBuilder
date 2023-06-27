using System.Diagnostics.CodeAnalysis;

namespace Zealot;

public static class TestDataBuilder
{
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        var entity = new TEntity();
        ISetOnlyTypeContainer setOnlyContainer = new SetOnlyTypeContainer();
        
        IContext context = new Context(entity, setOnlyContainer);
        
        IStrategyContainer strategyContainer = new StrategyContainer();
        
        var builder = new Builder<TEntity>(context, strategyContainer);
        return builder;
    }
}