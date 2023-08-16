using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class ArrayStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => info => info.IsArray;
    public override object GenerateValue(IContext context, Type type)
    {
        // var elementType = type.GetElementType();
        // var instance = Array.CreateInstance(elementType!, context.With.List.Size);
        //
        // var strategy = context.StrategyContainer.Resolve(elementType!);
        //     
        // for (var i = 0; i < context.With.List.Size; i++)
        // {
        //     var newContext = context.CloneWithType(elementType!);
        //     var value = strategy.ExecuteWithReturn(newContext);
        //     instance?.SetValue(value, i);
        // }
        //
        // return instance!;
        throw new NotImplementedException("GenerateValue");
    }

    public override object ExecuteWithReturn(IContext context)
    {
        var elementType = context.Scope.EntityType.GetElementType();
        var instance = Array.CreateInstance(elementType!, context.With.List.Size);

        var strategy = context.StrategyContainer.Resolve(elementType!);
            
        for (var i = 0; i < context.With.List.Size; i++)
        {
            var newContext = context.CloneWithType(elementType!);
            var value = strategy.ExecuteWithReturn(newContext);
            instance?.SetValue(value, i);
        }

        return instance!;
    }
}
