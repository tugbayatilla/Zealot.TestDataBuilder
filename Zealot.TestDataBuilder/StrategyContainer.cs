namespace Zealot;

public class StrategyContainer : IStrategyContainer
{
    private readonly IList<IStrategy> _registeredStrategies = new List<IStrategy>();

    public IStrategy Resolve(Type propertyType)
    {
        var strategy = _registeredStrategies.FirstOrDefault();
        if (strategy != null) return strategy;
        
        strategy = new NumberStrategy();
        _registeredStrategies.Add(strategy);
        return strategy;
    }
}