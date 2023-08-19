namespace Zealot.Interfaces;

internal interface IStrategyContainer
{
    IStrategy Resolve(Type type);
    void Register(IStrategy strategy);
}
