using System.Reflection;
using Zealot.Strategies;

namespace Zealot.Interfaces;

public interface IStrategyContainer
{
    IStrategy Resolve(Type propertyInfo);
    void Register(IStrategy strategy);
}