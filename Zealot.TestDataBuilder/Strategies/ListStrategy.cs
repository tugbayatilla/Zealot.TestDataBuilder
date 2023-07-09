using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ListStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes =>
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
    
    public override Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x.Name == info.Name);

    public override object GenerateValue(IContext context, Type type)
    {
        var listType = type;

        if (type is {IsInterface: true, IsGenericType: true})
        {
            listType = typeof(List<>).MakeGenericType(type.GenericTypeArguments);
        }

        var instance = Instance.Create(listType);
        
        if (instance == null) return null!;
        if (instance is not IList list) return instance;
        
        var argumentType = instance.GetType().GetGenericArguments().FirstOrDefault() ?? typeof(string);

        var strategy = context.StrategyContainer.Resolve(argumentType);
            
        for (var i = 0; i < 2; i++)
        {
            var value = strategy.GenerateValue(context, argumentType);
            list.Add(value);
        }

        return instance;
    }
}
