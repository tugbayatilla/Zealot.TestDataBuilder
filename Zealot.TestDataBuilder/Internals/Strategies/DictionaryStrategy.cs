﻿using System.Collections;

namespace Zealot.Internals.Strategies;

internal class DictionaryStrategy : IStrategy
{
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
        
        for (var i = 0; i < context.With.List.Size; i++)
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
        
        return propertyInstance;
    }
    private static IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(Dictionary<,>),
            typeof(IReadOnlyDictionary<,>)
        };
}
