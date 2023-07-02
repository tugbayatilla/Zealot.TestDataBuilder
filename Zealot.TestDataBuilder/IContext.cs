namespace Zealot;

public interface IContext
{
    public IContext CloneWithNew(object entity);
    
    object Entity { get; }
    IWithOnlyContainer WithOnlyContainer { get; }
    DateTime WithUtcDate { get; set; }
    Guid WithGuid { get; set; }
    IStrategyContainer StrategyContainer { get; }
}
