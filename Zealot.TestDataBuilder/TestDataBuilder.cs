using Zealot.Internals.Withs;

namespace Zealot;

/// <summary>
/// Test Data Builder
/// </summary>
public static class TestDataBuilder
{
    /// <summary>
    /// Default string body text
    /// </summary>
    public static readonly string DefaultStringBodyTemplate = "test_";
    
    /// <summary>
    /// Required
    /// </summary>
    public static ITestDataBuilder<TEntity> For<TEntity>()
    {
        IContext context = new Context(
            typeof(TEntity), 
            new With(),
            new StrategyContainer());

        return new TestDataBuilder<TEntity>(context);
    }
}
