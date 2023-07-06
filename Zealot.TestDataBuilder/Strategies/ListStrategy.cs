using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ListStrategy : Strategy
{
    //todo: split these different strategies
    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(List<>),
            typeof(IList<>),
            typeof(IList),
            typeof(ICollection<>),
            typeof(ICollection),
            typeof(ArrayList),
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

        return Instance.Create(listType);
    }
}
