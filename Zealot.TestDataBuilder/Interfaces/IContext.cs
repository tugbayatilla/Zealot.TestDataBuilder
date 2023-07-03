namespace Zealot.Interfaces;

public interface IContext
{
    public IContext CloneWithNew(object entity);
    
    object Entity { get; }
    DateTime WithUtcDate { get; set; }
    Guid WithGuid { get; set; }
    
    IStrategyContainer StrategyContainer { get; }
    IWithRecursionLevel WithRecursionLevel { get; }
    IWithOnly WithOnly { get; }
}
