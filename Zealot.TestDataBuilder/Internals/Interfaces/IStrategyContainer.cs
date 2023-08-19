namespace Zealot.Internals.Interfaces;

internal interface IStrategyContainer
{
    IStrategy Resolve(Type type);
}
