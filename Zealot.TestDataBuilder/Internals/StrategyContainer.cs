using Zealot.Internals.Interfaces;
using Zealot.Internals.Strategies;

namespace Zealot.Internals;

internal class StrategyContainer : IStrategyContainer
{
    private readonly IList<IStrategy> _registeredStrategies = new List<IStrategy>();

    public StrategyContainer()
    {
        _registeredStrategies.Add(new NumberStrategy());
        _registeredStrategies.Add(new StringStrategy());
        _registeredStrategies.Add(new CharStrategy());
        _registeredStrategies.Add(new ByteStrategy());
        _registeredStrategies.Add(new DictionaryStrategy());
        _registeredStrategies.Add(new ListStrategy());
        _registeredStrategies.Add(new ArrayStrategy());
        _registeredStrategies.Add(new EnumStrategy());
        _registeredStrategies.Add(new BooleanStrategy());
        _registeredStrategies.Add(new DatetimeStrategy());
        _registeredStrategies.Add(new GuidStrategy());
        _registeredStrategies.Add(new ClassStrategy());
    }
    
    public IStrategy Resolve(Type type)
    {
        var strategy = _registeredStrategies.FirstOrDefault(p => p.ResolveCondition.Compile().Invoke(type));
        if (strategy == null)
        {
            throw new NotSupportedException($"The strategy with type '{type.FullName}' is not supported.");
        }
        return strategy;
    }
}
