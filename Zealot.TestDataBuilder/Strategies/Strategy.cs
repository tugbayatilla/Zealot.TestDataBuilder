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
            var pi = context.Entity.GetType().GetProperty(context.Scope.PropertyName);
            pi.SecureSetValue(context.Entity, GenerateValue(context, pi.PropertyType));
        }
        else
        {
            context.SetEntity(GenerateValue(context, context.EntityType));
        }
    }
}
