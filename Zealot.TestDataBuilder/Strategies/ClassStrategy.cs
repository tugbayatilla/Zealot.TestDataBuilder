using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override object ExecuteWithReturn(IContext context)
    {
        var newContext = CreateNewContextIfItIsForAProperty(context, context.Scope.EntityType);

        if (BreakRecursion(newContext, context.Scope.EntityType))
            return default!;

        CreateAnInstanceOfAnEntityAndSetToScope(newContext);

        HandleForeachProperty(newContext);

        OverrideProperties(newContext);

        return newContext.Scope.Entity;
    }

    public override Expression<Func<Type, bool>> ResolveCondition => info =>
        (info.IsClass || info.IsStruct())
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);

    public override object GenerateValue(IContext context, Type type)
    {
        var newContext = CreateNewContextIfItIsForAProperty(context, type);

        if (BreakRecursion(newContext, type))
            return default!;

        CreateAnInstanceOfAnEntityAndSetToScope(newContext);

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
        var properties = newContext.Scope.EntityType.GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (newContext.With.Only.IgnoreThis(propertyInfo.PropertyType)) continue;

            var strategy = newContext.StrategyContainer.Resolve(propertyInfo.PropertyType);
            newContext.Scope = newContext.Scope with {PropertyName = propertyInfo.Name};

            strategy.Execute(newContext);
        }
    }

    private static void CreateAnInstanceOfAnEntityAndSetToScope(IContext context)
    {
        var newInstance = Instance.Create(context.Scope.EntityType);
        context.Scope = context.Scope with {Entity = newInstance};
    }

    private static IContext CreateNewContextIfItIsForAProperty(IContext context, Type type)
    {
        var itIsForAProperty = !string.IsNullOrWhiteSpace(context.Scope.PropertyName);
        return itIsForAProperty ? context.CloneWithType(type) : context;
    }

    private static bool BreakRecursion(IContext newContext, Type type)
    {
        return !newContext.With.RecursionLevel.CanContinueDeeper(newContext, type);
    }
}
