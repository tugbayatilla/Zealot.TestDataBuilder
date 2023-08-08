using Zealot.Interfaces;

namespace Zealot.Internals;

internal class Context : IContext
{
    public Context(Type entityType,
        IWith with,
        IStrategyContainer strategyContainer)
    {
        With = with;
        StrategyContainer = strategyContainer;

        Scope = new Scope(entityType, null, null, null);
    }

    public IStrategyContainer StrategyContainer { get; }
    public IWith With { get; }

    public Scope Scope { get; set; }

    public IContext CloneWithType(Type entityType)
    {
        var newContext = new Context(entityType,
            With,
            StrategyContainer);

        newContext.Scope = newContext.Scope with {Parent = Scope};

        return newContext;
    }
}