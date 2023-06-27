namespace Zealot;

public class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;
    private readonly IStrategyContainer _strategyContainer;

    public Builder(IContext context, IStrategyContainer strategyContainer)
    {
        _context = context;
        _strategyContainer = strategyContainer;
    }

    public TEntity Build()
    {
        // find properties
        var properties = typeof(TEntity).GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (_context.SetOnlyTypeContainer.IgnoreThis(propertyInfo.PropertyType)) continue;
            
            // find the Strategy for the type
            var strategy = _strategyContainer.Resolve(propertyInfo.PropertyType);
            // execute the strategy
            // TODO: parallelism 
            Task.Run(() => strategy.ExecuteAsync(_context, propertyInfo)).Wait();
        }

        return (TEntity)_context.Entity;
    }

    public IBuilder<TEntity> SetOnly<TProperty>()
    {
        return SetOnly(typeof(TProperty));
    }

    public IBuilder<TEntity> SetOnly(Type type)
    {
        _context.SetOnlyTypeContainer.Add(type);
        return this;
    }
}