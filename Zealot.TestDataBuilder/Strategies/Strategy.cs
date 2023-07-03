using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

public abstract class Strategy : IStrategy
{
    public abstract Task ExecuteAsync(IContext context, PropertyInfo propertyInfo);
    public virtual IEnumerable<Type> AvailableTypes { get; } = default!;
    public virtual Expression<Func<PropertyInfo, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info.PropertyType);
}
