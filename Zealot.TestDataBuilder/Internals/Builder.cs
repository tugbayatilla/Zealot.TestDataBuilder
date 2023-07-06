using Zealot.Interfaces;
using Zealot.Strategies;

namespace Zealot.Internals;

internal class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;
    private Action<TEntity> _withValueAction = default!;
    
    public Builder(IContext context)
    {
        _context = context;
        _context.WithRecursionLevel.Register(_context.Entity.GetType());
    }

    public TEntity Build()
    {
        // find properties
        var properties = _context.Entity.GetType().GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (_context.WithOnly.IgnoreThis(propertyInfo.PropertyType)) continue;

            // find the Strategy for the type
            var strategy = _context.StrategyContainer.Resolve(propertyInfo.PropertyType);
            // execute the strategy
            strategy.Execute(_context, propertyInfo);
        }
        
        _withValueAction?.Invoke((TEntity) _context.Entity);
        
        return (TEntity) _context.Entity;
    }

    public IBuilder<TEntity> WithOnly<TProperty>()
    {
        return WithOnly(typeof(TProperty));
    }

    public IBuilder<TEntity> WithOnly(Type type)
    {
        _context.WithOnly.Add(type);
        return this;
    }


    public IBuilder<TEntity> WithValue(Action<TEntity> action)
    {
        _withValueAction = action;
        return this;
    }

    public IBuilder<TEntity> WithDate(DateTime dateTime)
    {
        _context.WithUtcDate = dateTime;
        return this;
    }

    public IBuilder<TEntity> WithStrategy(IStrategy strategy)
    {
        _context.StrategyContainer.Register(strategy);
        return this;
    }

    public IBuilder<TEntity> WithGuid(Guid guid)
    {
        _context.WithGuid = guid;
        return this;
    }

    public IBuilder<TEntity> WithRecursionLevel(int recursionLevel)
    {
        _context.WithRecursionLevel.SetAllowedRecursionLevel(recursionLevel);
        return this;
    }
}