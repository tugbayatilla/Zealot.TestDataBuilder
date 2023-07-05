using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class DictionaryStrategy : Strategy
{
    private const int SizeOfList = 2;
    
    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };

    public override Expression<Func<Type, bool>> ResolveCondition
        => info => AvailableTypes.Any(x => x.Name == info.Name);

    public override object GenerateValue(IContext context, Type type)
    {
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
            var key = strategy1.GenerateValue(context, arguments[0]);

            var strategy2 = context.StrategyContainer.Resolve(arguments[1]);
            var value = strategy2.GenerateValue(context, arguments[1]);

            propertyInstance.Add(key, value);
        }
        
        return propertyInstance;
    }
}
