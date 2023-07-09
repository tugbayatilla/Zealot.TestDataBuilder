using Zealot.Interfaces;
using Zealot.Strategies;

namespace Zealot.Internals;

internal class Builder<TEntity> : IBuilder<TEntity>, IBuilder
    where TEntity : new()
{
    private readonly IContext _context;
    private readonly List<Action<TEntity>> _withValueAction = new();
    
    public Builder(IContext context)
    {
        _context = context;
    }

    public TEntity Build()
    {
        var newInstance = Instance.Create(_context.EntityType);
        if (newInstance == null) return default!;
        
        _context.SetEntity(newInstance); 
        
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
        
        _withValueAction.ForEach(p=>p.Invoke((TEntity) _context.Entity));
        
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
        _withValueAction.Add(action);
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

    public IBuilder<TEntity> WithStringPrefix(string prefix)
    {
        _context.WithStringPrefix = prefix;
        return this;
    }

    public IBuilder<TEntity> WithStringSuffix(string suffix)
    {
        _context.WithStringSuffix = suffix;
        return this;
    }

    public IBuilder<TEntity> WithStartingNumber(int startingNumber)
    {
        _context.WithStartingNumber = startingNumber;
        return this;
    }

    object IBuilder.Build()
    {
        return Build();
    }
    
    //todo: add WithLogger
}