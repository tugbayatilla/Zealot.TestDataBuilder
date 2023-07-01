using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

public abstract class Strategy : IStrategy
{
    public abstract Task ExecuteAsync(IContext context, PropertyInfo propertyInfo);
    public abstract IEnumerable<Type> AvailableTypes { get; }
    
    public virtual Expression<Func<PropertyInfo, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x.Name == info.PropertyType.Name);
}