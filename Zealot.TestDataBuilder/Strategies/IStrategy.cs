using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

public interface IStrategy
{
    Task ExecuteAsync(IContext context, PropertyInfo propertyInfo);
    IEnumerable<Type> AvailableTypes { get; }
    Expression<Func<PropertyInfo, bool>> ResolveCondition { get; }
}
