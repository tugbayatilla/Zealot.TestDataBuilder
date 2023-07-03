using System.Reflection;
using Zealot.Strategies;

namespace Zealot.Interfaces;

public interface IStrategyContainer
{
    IStrategy Resolve(PropertyInfo propertyInfo);
    IEnumerable<IStrategy> ResolveAll(PropertyInfo propertyInfo);
    void Register(IStrategy strategy);
}