using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal abstract class Strategy : IStrategy
{
    public virtual IEnumerable<Type> AvailableTypes { get; } = default!;
    public virtual Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public abstract object GenerateValue(IContext context, Type type);

    public virtual void Execute(IContext context)
    {
        if (!string.IsNullOrWhiteSpace(context.Scope.PropertyName))
        {
            var pi = context.Scope.Entity.GetType().GetProperty(context.Scope.PropertyName);
            pi.SecureSetValue(context.Scope.Entity, GenerateValue(context, pi.PropertyType));
        }
        else
        {
            object entity = GenerateValue(context, context.Scope.EntityType);
            context.Scope = context.Scope with {Entity = entity};
        }
    }
}
