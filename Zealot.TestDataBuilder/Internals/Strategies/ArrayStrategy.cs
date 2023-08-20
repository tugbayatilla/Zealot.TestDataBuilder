namespace Zealot.Internals.Strategies;

internal class ArrayStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition => info => info.IsArray;

    public object? Execute(IContext context)
    {
        var elementType = context.Scope.EntityType.GetElementType();
        var instance = Array.CreateInstance(elementType!, context.With.List.Size);

        var strategy = context.StrategyContainer.Resolve(elementType!);
            
        for (var i = 0; i < context.With.List.Size; i++)
        {
            var newContext = context.CloneWithType(elementType!);
            var value = strategy.Execute(newContext);
            instance?.SetValue(value, i);
        }

        return instance;
    }
}
