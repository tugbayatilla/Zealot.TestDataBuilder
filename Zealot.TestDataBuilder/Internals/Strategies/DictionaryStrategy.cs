using System.Collections;

namespace Zealot.Internals.Strategies;

internal class DictionaryStrategy : IStrategy
{
    private const int SizeOfList = 2;
    
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

        var propertyInstance = Instance.Create(propertyType, context) as IDictionary;

        var arguments = propertyInstance!.GetType().GetGenericArguments();

        var backupWith = context.With;
        context.With.String.Separator.IsSet = true;
        context.With.String.Separator.Value = "_";
        context.With.String.StringUniqueStartNumber.IsSet = true;
        context.With.String.StringUniqueStartNumber.Value = 1;
        
        for (var i = 0; i < SizeOfList; i++)
        {
            var strategy1 = context.StrategyContainer.Resolve(arguments[0]);
            var newContext1 = context.CloneWithType(arguments[0]);
            var key = strategy1.Execute(newContext1);
            if (key == null) continue;
            
            var strategy2 = context.StrategyContainer.Resolve(arguments[1]);
            var newContext2 = context.CloneWithType(arguments[1]);
            var value = strategy2.Execute(newContext2);
            
            propertyInstance.Add(key, value);
        }

        context.With.String.Separator = backupWith.String.Separator;
        context.With.String.StringUniqueStartNumber = backupWith.String.StringUniqueStartNumber;
        
        
        return propertyInstance;
    }
    private static IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };
}
