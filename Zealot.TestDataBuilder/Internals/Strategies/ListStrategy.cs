using System.Collections;

namespace Zealot.Internals.Strategies;

internal class ListStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x.Name == info.Name);

    public object? Execute(IContext context)
    {
        var listType = context.Scope.EntityType;
        listType = ChangeListTypeIfGeneric(context, listType);

        var list = GetListInstanceIfInitializedInProperty(context);

        list ??= Instance.Create(listType, context);
        
        FillListWithData(context, ref list);

        return list;
    }

    private static object? GetListInstanceIfInitializedInProperty(IContext context)
    {
        if (!string.IsNullOrWhiteSpace(context.Scope.ParentPropertyName))
        {
            var pi = context.Scope.Parent!.EntityType.GetProperty(context.Scope.ParentPropertyName);
            return pi!.GetValue(context.Scope.Parent.Entity, null);
        }

        return null;
    }

    private static Type ChangeListTypeIfGeneric(IContext context, Type listType)
    {
        if (context.Scope.EntityType is {IsInterface: true, IsGenericType: true})
        {
            listType = typeof(List<>).MakeGenericType(context.Scope.EntityType.GenericTypeArguments);
        }

        return listType;
    }

    private static void FillListWithData(IContext context, ref object? instance)
    {
        if (instance == null) return;
        
        var argumentType = instance.GetType().GetGenericArguments().FirstOrDefault() ?? typeof(string);
        var strategy = context.StrategyContainer.Resolve(argumentType);

        for (var i = 0; i < context.With.List.Size; i++)
        {
            var newContext = context.CloneWithType(argumentType);
            newContext.Scope = newContext.Scope with {ParentPropertyName = context.Scope.ParentPropertyName};
            var value = strategy.Execute(newContext);

            (instance as Queue)?.Enqueue(value);
            (instance as Stack)?.Push(value);

            if (instance is ICollection)
            {
                (instance as IList)?.Add(value);
            }

            if (instance.GetType().Name == typeof(Queue<>).Name)
            {
                (instance as dynamic).Enqueue(value);
            }

            if (instance.GetType().Name == typeof(Stack<>).Name)
            {
                (instance as dynamic).Push(value);
            }
        }
    }

    private static IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(ArrayList),
            typeof(List<>),
            typeof(IList<>),
            typeof(IList),
            typeof(ICollection<>),
            typeof(ICollection),
            typeof(LinkedList<>),
            typeof(Queue<>),
            typeof(Queue),
            typeof(Stack),
            typeof(Stack<>),
            typeof(IEnumerable<>),
            typeof(IEnumerable),
            typeof(IReadOnlyCollection<>),
            typeof(IReadOnlyList<>)
        };
}
