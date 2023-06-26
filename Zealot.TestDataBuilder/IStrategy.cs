using System.Reflection;

namespace Zealot;

public interface IStrategy<in TEntity>
{
    Task ExecuteAsync(IContext context, TEntity entity, PropertyInfo propertyInfo);
    IEnumerable<Type> AvailableTypes { get; }
}