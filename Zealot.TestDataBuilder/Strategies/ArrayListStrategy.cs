using System.Collections;
using System.Linq.Expressions;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ArrayListStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(ArrayList)
        };
    
    public override Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x.Name == info.Name);

    public override object GenerateValue(IContext context, Type type)
    {
        var instance = Instance.Create(type) as ArrayList;

        if (instance == null) return null!;
        
        var strategy = context.StrategyContainer.Resolve(typeof(int));
        for (int i = 0; i < 2; i++)
        {
            var value = strategy.GenerateValue(context, typeof(int));
            instance.Add(value);
        }

        return instance;
    }
}
