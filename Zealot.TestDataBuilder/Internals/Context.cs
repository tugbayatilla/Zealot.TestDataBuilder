using Zealot.Interfaces;

namespace Zealot.Internals;

internal class Context : IContext
{
    public Context(object entity, 
        IWithOnly withOnly, 
        IStrategyContainer strategyContainer, 
        IWithRecursionLevel withRecursionLevel)
    {
        Entity = entity;
        WithOnly = withOnly;
        StrategyContainer = strategyContainer;
        WithRecursionLevel = withRecursionLevel;
    }

    public IContext CloneWithNew(object entity)
    {
        var newContext = new Context(entity, 
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

    public DateTime WithUtcDate { get; set; } = DateTime.UtcNow;
    public Guid WithGuid { get; set; } = Guid.NewGuid();
}