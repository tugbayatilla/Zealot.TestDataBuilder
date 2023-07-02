namespace Zealot;

internal class Context : IContext
{
    public Context(object entity, IWithOnlyContainer withOnlyContainer, IStrategyContainer strategyContainer)
    {
        Entity = entity;
        WithOnlyContainer = withOnlyContainer;
        StrategyContainer = strategyContainer;
    }

    public IContext CloneWithNew(object entity)
    {
        var newContext = new Context(entity, WithOnlyContainer, StrategyContainer)
        {
            WithUtcDate = WithUtcDate,
            WithGuid = WithGuid
        };

        return newContext;
    }

    public object Entity { get; private set; }
    public IWithOnlyContainer WithOnlyContainer { get; }
    public IStrategyContainer StrategyContainer { get; }
    public DateTime WithUtcDate { get; set; } = DateTime.UtcNow;
    public Guid WithGuid { get; set; } = Guid.NewGuid();
}