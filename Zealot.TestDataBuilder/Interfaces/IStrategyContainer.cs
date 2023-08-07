using Zealot.Strategies;

namespace Zealot.Interfaces;

public interface IStrategyContainer
{
    IStrategy Resolve(Type type);
    void Register(IStrategy strategy);
}
