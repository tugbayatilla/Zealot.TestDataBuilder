using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => info => 
        (info.IsClass || info.IsStruct()) 
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);
    
    public override object GenerateValue(IContext context, Type type)
    {
        var newContext = context.CloneWithType(type);
        if (string.IsNullOrWhiteSpace(context.Scope.PropertyName))
        {
            newContext = context;    
        }
        
        // break recursion
        if (!newContext.With.RecursionLevel.CanContinueDeeper(newContext, type))
            return default!;

        var newInstance = Instance.Create(newContext.Scope.EntityType);
        if (newInstance == null) return default!;

        newContext.Scope = newContext.Scope with {Entity = newInstance};
        
        // find properties
        var properties = newContext.Scope.Entity.GetType().GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (newContext.With.Only.IgnoreThis(propertyInfo.PropertyType)) continue;

            // find the Strategy for the type
            var strategy = newContext.StrategyContainer.Resolve(propertyInfo.PropertyType);
            newContext.Scope = newContext.Scope with {PropertyName = propertyInfo.Name}; 
            
            // execute the strategy
            strategy.Execute(newContext);
        }

        newContext.With.Override.Apply(newContext.Scope.Entity);

        return newContext.Scope.Entity;
    }
}
