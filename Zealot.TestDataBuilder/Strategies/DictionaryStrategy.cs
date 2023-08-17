using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class DictionaryStrategy : IStrategy
{
    private const int SizeOfList = 2;
    
    public IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };

    public Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x.Name == info.Name);

    public object Execute(IContext context)
    {
        var type = context.Scope.EntityType;
        var propertyType = type;

        if (type is {IsInterface: true, IsGenericType: true})
        {
            propertyType = typeof(Dictionary<,>).MakeGenericType(type.GenericTypeArguments);
        }

        var propertyInstance = Instance.Create(propertyType) as IDictionary;

        var arguments = propertyInstance.GetType().GetGenericArguments();

        for (var i = 0; i < SizeOfList; i++)
        {
            var strategy1 = context.StrategyContainer.Resolve(arguments[0]);
            var newContext1 = context.CloneWithType(arguments[0]);
            var key = strategy1.Execute(newContext1);

            var strategy2 = context.StrategyContainer.Resolve(arguments[1]);
            var newContext2 = context.CloneWithType(arguments[1]);
            var value = strategy2.Execute(newContext2);

            propertyInstance.Add(key, value);
        }
        
        return propertyInstance;
    }
}
