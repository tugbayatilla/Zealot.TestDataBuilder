using System.Reflection;
using Zealot.Strategies;

namespace Zealot;

public interface IStrategyContainer
{
    IStrategy Resolve(PropertyInfo propertyInfo);
}