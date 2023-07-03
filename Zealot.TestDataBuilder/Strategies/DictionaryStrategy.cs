using System.Collections;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class DictionaryStrategy : Strategy
{
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

        var propertyInstance = Instance.Create(propertyType);

        if (propertyInstance is IDictionary dict)
        {
            var arguments = propertyInstance.GetType().GetGenericArguments();

            for (var i = 0; i < 2; i++)
            {
                var strategy1 = context.StrategyContainer.Resolve(arguments[0]);
                var key = strategy1.GenerateValue(context, arguments[0]);

                var strategy2 = context.StrategyContainer.Resolve(arguments[1]);
                var value = strategy2.GenerateValue(context, arguments[1]);

                dict.Add(key, value);
            }
        }

        return propertyInstance;
    }
}