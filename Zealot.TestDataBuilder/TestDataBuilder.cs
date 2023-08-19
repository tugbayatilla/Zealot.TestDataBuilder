using Zealot.Internals;
using Zealot.Internals.Interfaces;
using Zealot.Internals.Withs;

namespace Zealot;

public static class TestDataBuilder
{
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> For<TEntity>()
    {
        IContext context = new Context(
            typeof(TEntity), 
            new With(),
            new StrategyContainer());

        return new Builder<TEntity>(context);
    }
}
