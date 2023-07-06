using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ArrayStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => info => info.IsArray;
    public override object GenerateValue(IContext context, Type type)
    {
        var instanceType = type;

        if (type is {IsInterface: true, IsGenericType: true})
        {
            instanceType = typeof(List<>).MakeGenericType(type.GenericTypeArguments);
        }

        var elementType = instanceType.GetElementType();
        var instance = Array.CreateInstance(elementType, 2);
        
        if (instance == null) return null!;
        
        var strategy = context.StrategyContainer.Resolve(elementType);
            
        for (var i = 0; i < 2; i++)
        {
            var value = strategy.GenerateValue(context, elementType);
            instance.SetValue(value, i);
        }

        return instance;
    }
}
