namespace Zealot.Interfaces;

internal interface IStrategyContainer
{
    IStrategy Resolve(Type type);
}
