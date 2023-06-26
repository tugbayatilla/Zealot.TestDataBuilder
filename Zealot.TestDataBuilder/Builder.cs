namespace Zealot;

public class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;
    private IStrategy<TEntity> _numberStrategy;

    public Builder(IContext context)
    {
        _context = context;
    }

    public TEntity Build()
    {
        var entity = new TEntity();
        
        // find properties
        var properties = typeof(TEntity).GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            // find the Type of the property
            // find the Strategy for the type, create if necessary
            var strategy = FindStrategy(propertyInfo.PropertyType);
            // execute the strategy
            // TODO: parallelism 
            Task.Run(() => strategy.ExecuteAsync(_context, entity, propertyInfo)).Wait();
        }

        return entity;
    }

    private IStrategy<TEntity> FindStrategy(Type propertyType)
    {
        if (_numberStrategy == null)
        {
            _numberStrategy = new NumberStrategy<TEntity>();
        }

        return _numberStrategy;
    }
}