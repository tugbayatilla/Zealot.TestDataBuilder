namespace Zealot.Interfaces;

public interface IContext
{
    public IContext CloneWithNew(object entity);
    
    public IContext? Parent { get; }
    
    object Entity { get; }
    void SetEntity(object entity);
    
    DateTime WithUtcDate { get; set; }
    Guid WithGuid { get; set; }
    
    IStrategyContainer StrategyContainer { get; }
    IWithRecursionLevel WithRecursionLevel { get; }
    IWithOnly WithOnly { get; }
}
