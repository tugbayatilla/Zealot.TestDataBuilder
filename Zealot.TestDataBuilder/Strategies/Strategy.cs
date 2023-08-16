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
            var pi = context.Scope.EntityType.GetProperty(context.Scope.PropertyName);
            pi.SecureSetValue(context.Scope.Entity, GenerateValue(context, pi.PropertyType));
        }
        else
        {
            object entity = GenerateValue(context, context.Scope.EntityType);
            context.Scope = context.Scope with {Entity = entity};
        }
    }

    public virtual object ExecuteWithReturn(IContext context)
    {
        // if (!string.IsNullOrWhiteSpace(context.Scope.PropertyName))
        // {
        //     var pi = context.Scope.EntityType.GetProperty(context.Scope.PropertyName);
        //     var strategy = context.StrategyContainer.Resolve(pi.PropertyType);
        //     var newContext = context.CloneWithType(pi.PropertyType);
        //     var generateValue = strategy.ExecuteWithReturn(newContext);
        //     pi.SecureSetValue(context.Scope.Entity, generateValue);
        // }
        // else
        // {
        //     var entity = GenerateValue(context, context.Scope.EntityType);
        //     context.Scope = context.Scope with {Entity = entity};
        // }
        //
        // return context.Scope.Entity;
        throw new NotImplementedException(context.Scope.EntityType.Name);
    }
}
