namespace Zealot;

public class StrategyContainer : IStrategyContainer
{
    private readonly IList<IStrategy> _registeredStrategies = new List<IStrategy>();

    public StrategyContainer()
    {
        // todo: not a good idea
        _registeredStrategies.Add(new NumberStrategy());
        _registeredStrategies.Add(new StringStrategy());
    }
    
    public IStrategy Resolve(Type propertyType)
    {
        var strategy = _registeredStrategies.FirstOrDefault(p => p.AvailableTypes.Contains(propertyType));
        if (strategy == null)
        {
            throw new NotSupportedException($"The strategy with type '{propertyType.FullName}' is not supported.");
        }
        return strategy;
    }
}
