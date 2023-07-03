using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

public abstract class Strategy : IStrategy
{
    public virtual IEnumerable<Type> AvailableTypes { get; } = default!;
    public virtual Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public abstract object GenerateValue(IContext context, Type type);

    public virtual void SetValue(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, GenerateValue(context, propertyInfo.PropertyType));
    }

}
