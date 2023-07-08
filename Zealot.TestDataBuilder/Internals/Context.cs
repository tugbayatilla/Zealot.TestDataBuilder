using Zealot.Interfaces;

namespace Zealot.Internals;

internal class Context : IContext
{
    public Context(Type entityType, 
        IWithOnly withOnly, 
        IStrategyContainer strategyContainer, 
        IWithRecursionLevel withRecursionLevel)
    {
        EntityType = entityType;
        WithOnly = withOnly;
        StrategyContainer = strategyContainer;
        WithRecursionLevel = withRecursionLevel;
    }

    public Type EntityType { get; private set; }

    public IContext CloneWithType(Type entityType)
    {
        var newContext = new Context(entityType, 
            WithOnly, 
            StrategyContainer, 
            WithRecursionLevel)
        {
            WithUtcDate = WithUtcDate,
            WithGuid = WithGuid
        };

        newContext.Parent = this;
        
        return newContext;
    }

    public IContext? Parent { get; private set; }

    public object Entity { get; private set; }
    public IWithOnly WithOnly { get; }
    public IStrategyContainer StrategyContainer { get; }
    public IWithRecursionLevel WithRecursionLevel { get; }

    public void SetEntity(object entity)
    {
        Entity = entity;
    }

    public DateTime WithUtcDate { get; set; } = DateTime.UtcNow;
    public Guid WithGuid { get; set; } = Guid.NewGuid();
}