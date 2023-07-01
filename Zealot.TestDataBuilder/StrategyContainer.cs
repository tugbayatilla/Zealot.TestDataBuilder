using System.Reflection;
using Zealot.Strategies;

namespace Zealot;

public class StrategyContainer : IStrategyContainer
{
    private readonly IList<IStrategy> _registeredStrategies = new List<IStrategy>();

    public StrategyContainer()
    {
        // todo: not a good idea
        _registeredStrategies.Add(new NumberStrategy());
        _registeredStrategies.Add(new StringStrategy());
        _registeredStrategies.Add(new CharStrategy());
        _registeredStrategies.Add(new ByteStrategy());
        _registeredStrategies.Add(new DictionaryStrategy());
        _registeredStrategies.Add(new ListStrategy());
        _registeredStrategies.Add(new ArrayStrategy());
    }
    
    public IStrategy Resolve(PropertyInfo propertyInfo)
    {
        var strategy = _registeredStrategies.FirstOrDefault(p => p.ResolveCondition.Compile().Invoke(propertyInfo));
        if (strategy == null)
        {
            throw new NotSupportedException($"The strategy with type '{propertyInfo.PropertyType.FullName}' is not supported.");
        }
        return strategy;
    }
}