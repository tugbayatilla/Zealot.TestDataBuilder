namespace Zealot;

public interface IStrategyContainer
{
    IStrategy Resolve(Type propertyType);
}