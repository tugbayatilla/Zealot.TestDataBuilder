namespace Zealot.Internals.Strategies;

internal class GuidStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        if (context.With.Default.IsUsingDefault)
            return Guid.Empty;
        
        return context.With.Guid.Guid;
    }
    private static IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(Guid?),typeof(Guid)
    };
}
