using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ListStrategy : IStrategy
{
    public IEnumerable<Type> AvailableTypes =>
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

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x.Name == info.Name);

    public object Execute(IContext context)
    {
        var type = context.Scope.EntityType;
        var listType = type;

        if (type is {IsInterface: true, IsGenericType: true})
        {
            listType = typeof(List<>).MakeGenericType(type.GenericTypeArguments);
        }

        var instance = Instance.Create(listType);

        if (instance == null) return null!;
        var argumentType = instance.GetType().GetGenericArguments().FirstOrDefault() ?? typeof(string);
        var strategy = context.StrategyContainer.Resolve(argumentType);

        for (var i = 0; i < context.With.List.Size; i++)
        {
            var newContext = context.CloneWithType(argumentType);
            newContext.Scope = newContext.Scope with {PropertyName = context.Scope.PropertyName};
            var value = strategy.Execute(newContext);

            if (instance is Queue queueInstance)
            {
                queueInstance.Enqueue(value);
            }

            if (instance is Stack stackInstance)
            {
                stackInstance.Push(value);
            }

            if (instance is ICollection)
            {
                (instance as IList)?.Add(value);
            }

            if (instance.GetType().Name == typeof(Queue<>).Name)
            {
                (instance as dynamic)?.Enqueue(value);
            }

            if (instance.GetType().Name == typeof(Stack<>).Name)
            {
                (instance as dynamic)?.Push(value);
            }
        }

        return instance;
    }
}
