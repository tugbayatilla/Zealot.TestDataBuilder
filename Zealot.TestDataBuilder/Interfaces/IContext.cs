namespace Zealot.Interfaces;

public interface IContext
{
    IContext CloneWithType(Type entityType);
    
    public IContext? Parent { get; }
    
    object Entity { get; }
    void SetEntity(object entity);
    
    Type EntityType { get; }
    
    DateTime WithUtcDate { get; set; }
    Guid WithGuid { get; set; }
    
    IStrategyContainer StrategyContainer { get; }
    IWithRecursionLevel WithRecursionLevel { get; }
    IWithOnly WithOnly { get; }
}
