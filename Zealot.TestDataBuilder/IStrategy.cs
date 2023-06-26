using System.Reflection;

namespace Zealot;

public interface IStrategy
{
    Task ExecuteAsync(IContext context, PropertyInfo propertyInfo);
    IEnumerable<Type> AvailableTypes { get; }
}