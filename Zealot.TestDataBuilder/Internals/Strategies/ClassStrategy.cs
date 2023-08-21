namespace Zealot.Internals.Strategies;

internal class ClassStrategy : IStrategy
{
    public object? Execute(IContext context)
    {
        var newContext = CreateNewContextIfItIsForAProperty(context, context.Scope.EntityType);

        if (BreakRecursion(newContext, context.Scope.EntityType))
            return default!;

        CreateAnInstanceOfAnEntityAndSetToScope(newContext);

        HandleForeachProperty(newContext);

        OverrideProperties(newContext);

        return newContext.Scope.Entity;
    }

    public Expression<Func<Type, bool>> ResolveCondition => info =>
        (info.IsClass || info.IsStruct())
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);

    private static void OverrideProperties(IContext context)
    {
        if (context.Scope.Entity == null) return;
        context.With.Override.Apply(context.Scope.Entity);
    }

    private static void HandleForeachProperty(IContext context)
    {
        var properties = context.Scope.EntityType.GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (context.With.Only.IgnoreThis(propertyInfo.PropertyType)) continue;

            
            var newContext = context.CloneWithType(propertyInfo.PropertyType);
            newContext.Scope = newContext.Scope with {ParentPropertyName = propertyInfo.Name};
            
            var entity = newContext
                .StrategyContainer
                .Resolve(propertyInfo.PropertyType)
                .Execute(newContext);
            
            newContext.Scope = newContext.Scope with {Entity = entity};

            
            var pi = newContext.Scope.Parent.EntityType.GetProperty(newContext.Scope.ParentPropertyName);
            pi.SecureSetValue(newContext.Scope.Parent.Entity, newContext.Scope.Entity);
            
        }
    }

    private static void CreateAnInstanceOfAnEntityAndSetToScope(IContext context)
    {
        var newInstance = Instance.Create(context.Scope.EntityType);
        context.Scope = context.Scope with {Entity = newInstance};
    }

    private static IContext CreateNewContextIfItIsForAProperty(IContext context, Type type)
    {
        var itIsForAProperty = !string.IsNullOrWhiteSpace(context.Scope.ParentPropertyName);
        return itIsForAProperty ? context.CloneWithType(type) : context;
    }

    private static bool BreakRecursion(IContext newContext, Type type)
    {
        return !newContext.With.RecursionLevel.CanContinueDeeper(newContext, type);
    }
}
