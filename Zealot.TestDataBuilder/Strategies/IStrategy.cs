using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

public interface IStrategy
{
    IEnumerable<Type> AvailableTypes { get; }
    Expression<Func<Type, bool>> ResolveCondition { get; }
    object GenerateValue(IContext context, Type type);
    void SetValue(IContext context, PropertyInfo propertyInfo);
}
