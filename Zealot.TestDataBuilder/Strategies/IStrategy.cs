using System.Reflection;

namespace Zealot.Strategies;

public interface IStrategy
{
    Task ExecuteAsync(IContext context, PropertyInfo propertyInfo);
    IEnumerable<Type> AvailableTypes { get; }
}