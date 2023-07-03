namespace Zealot;

public interface IContext
{
    public IContext CloneWithNew(object entity);
    
    object Entity { get; }
    DateTime WithUtcDate { get; set; }
    Guid WithGuid { get; set; }
    
    IStrategyContainer StrategyContainer { get; }
    IWithRecursionLevelContainer WithRecursionLevelContainer { get; }
    IWithOnlyContainer WithOnlyContainer { get; }
}
