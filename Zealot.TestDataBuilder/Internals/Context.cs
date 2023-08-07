using Zealot.Interfaces;

namespace Zealot.Internals;

//todo: make this class move friendly. we need more higher level to hold configuration so
// when we clone the context, configuration will not be transferred and copied to next context.
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
    public string PropertyName { get; set; }
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
