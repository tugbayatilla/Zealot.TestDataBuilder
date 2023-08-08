namespace Zealot.Interfaces;

public interface IContext
{
    IContext CloneWithType(Type entityType);
    IStrategyContainer StrategyContainer { get; }
    IWith With { get; }
    Scope Scope { get; set; }
}