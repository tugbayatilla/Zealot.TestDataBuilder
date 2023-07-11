using Zealot.Interfaces;

namespace Zealot.Internals;

internal class Context : IContext
{ 
    public Context(Type entityType, 
        IWith with, 
        IStrategyContainer strategyContainer)
    {
        EntityType = entityType;
        With = with;
        StrategyContainer = strategyContainer;
    }

    public Type EntityType { get; private set; }
    public IContext? Parent { get; private set; }
    public object Entity { get; private set; }
    public IStrategyContainer StrategyContainer { get; }
    public IWith With { get; }

    public void SetEntity(object entity)
    {
        Entity = entity;
    }
    
    public IContext CloneWithType(Type entityType)
    {
        var newContext = new Context(entityType, 
            With, 
            StrategyContainer);

        newContext.Parent = this;
        
        return newContext;
    }
}
