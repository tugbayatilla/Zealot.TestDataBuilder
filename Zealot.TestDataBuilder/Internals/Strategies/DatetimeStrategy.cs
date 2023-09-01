namespace Zealot.Internals.Strategies;

internal class DatetimeStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x == info);

    public object Execute(IContext context)
    {
        return context.With.Date.UtcDate;
    }
    
    private static IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };
}
