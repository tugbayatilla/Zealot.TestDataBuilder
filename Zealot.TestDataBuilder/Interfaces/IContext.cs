namespace Zealot.Interfaces;

public interface IContext
{
    IContext CloneWithType(Type entityType);
    
    public IContext? Parent { get; }
    
    object Entity { get; }
    void SetEntity(object entity);
    
    Type EntityType { get; }

    IStrategyContainer StrategyContainer { get; }
    IWith With { get; }
    
    Scope Scope { get; set; }
}

public record Scope(object Entity, Type EntityType, string PropertyName, Scope Parent);