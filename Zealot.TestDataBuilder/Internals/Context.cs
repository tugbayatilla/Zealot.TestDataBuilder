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
    public IContext? Parent { get; private set; }
    public object Entity { get; private set; }
    public IStrategyContainer StrategyContainer { get; }
    
    public IWithOnly WithOnly { get; } //todo: merge with(s) in one object
    public IWithRecursionLevel WithRecursionLevel { get; }
    public DateTime WithUtcDate { get; set; } = DateTime.UtcNow; //todo: support default values if they exist
    public Guid WithGuid { get; set; } = Guid.NewGuid();
    public string WithStringSuffix { get; set; }
    public string WithStringPrefix { get; set; }
    public int WithStartingNumber { get; set; } = 1;

    public void SetEntity(object entity)
    {
        Entity = entity;
    }
    
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
}
