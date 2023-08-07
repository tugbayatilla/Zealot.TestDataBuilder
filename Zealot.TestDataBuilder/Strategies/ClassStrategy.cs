using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override void Execute(IContext context)
    {
        if (!string.IsNullOrWhiteSpace(context.PropertyName))
        {
            var pi = context.Entity.GetType().GetProperty(context.PropertyName);

          //  if (!context.With.RecursionLevel.CanContinueDeeper(context, pi.PropertyType))
          //      return;
        }

        base.Execute(context);
    }

    public override Expression<Func<Type, bool>> ResolveCondition => info => 
        (info.IsClass || info.IsStruct()) 
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);
    
    public override object GenerateValue(IContext context, Type type) //todo: get rid of Type argument in GenerateValue method
    {
        
        var newContext = context.CloneWithType(type);
        if (string.IsNullOrWhiteSpace(context.PropertyName))
        {
            newContext = context;    
        }
        
        if (!newContext.With.RecursionLevel.CanContinueDeeper(newContext, type))
            return default!;

        var newInstance = Instance.Create(newContext.EntityType);
        if (newInstance == null) return default!;

        newContext.SetEntity(newInstance);

        
        // find properties
        var properties = newContext.Entity.GetType().GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (newContext.With.Only.IgnoreThis(propertyInfo.PropertyType)) continue;

            // find the Strategy for the type
            var strategy = newContext.StrategyContainer.Resolve(propertyInfo.PropertyType);
            newContext.PropertyName = propertyInfo.Name;
            
            // execute the strategy
            strategy.Execute(newContext);
        }

        newContext.With.Override.Apply(newContext.Entity);

        return newContext.Entity;
    }
}
