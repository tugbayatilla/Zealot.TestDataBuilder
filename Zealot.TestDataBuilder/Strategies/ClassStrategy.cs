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
        var newContext = HandleContext(context, type);

        // break recursion
        if (BreakRecursion(type, newContext))
            return default!;

        CreateEntity(newContext);

        HandleForeachProperty(newContext);

        OverrideProperties(newContext);

        return newContext.Scope.Entity;
    }

    private static void OverrideProperties(IContext newContext)
    {
        newContext.With.Override.Apply(newContext.Scope.Entity);
    }

    private static void HandleForeachProperty(IContext newContext)
    {
        // find properties
        var properties = newContext.Scope.EntityType.GetProperties();
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
    }

    private static void CreateEntity(IContext newContext)
    {
        var newInstance = Instance.Create(newContext.Scope.EntityType);
        newContext.Scope = newContext.Scope with {Entity = newInstance};
    }

    private static IContext HandleContext(IContext context, Type type)
    {
        var newContext = context;
        var itIsAPropertyOfAClass = !string.IsNullOrWhiteSpace(context.Scope.PropertyName);
        if (itIsAPropertyOfAClass)
        {
            // create a new context
            newContext = context.CloneWithType(type);
        }

        return newContext;
    }

    private static bool BreakRecursion(Type type, IContext newContext)
    {
        return !newContext.With.RecursionLevel.CanContinueDeeper(newContext, type);
    }
}