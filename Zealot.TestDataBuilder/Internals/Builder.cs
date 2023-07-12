using Microsoft.Extensions.Logging;
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
        _context.With.Log.Logger.LogDebug("{ExecuteName} for {EntityType} starts", nameof(Build), _context.EntityType.Name);
        
        var newInstance = Instance.Create(_context.EntityType);
        if (newInstance == null) return default!;
        
        _context.SetEntity(newInstance); 
        
        // find properties
        var properties = _context.Entity.GetType().GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (_context.With.Only.IgnoreThis(propertyInfo.PropertyType)) continue;

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
        _context.With.Only.Add(type);
        return this;
    }


    public IBuilder<TEntity> WithValue(Action<TEntity> action)
    {
        _withValueAction.Add(action);
        return this;
    }

    public IBuilder<TEntity> WithDate(DateTime dateTime)
    {
        _context.With.Date.UtcDate = dateTime;
        return this;
    }

    public IBuilder<TEntity> WithStrategy(IStrategy strategy)
    {
        _context.StrategyContainer.Register(strategy);
        return this;
    }

    public IBuilder<TEntity> WithGuid(Guid guid)
    {
        _context.With.Guid.Guid = guid;
        return this;
    }

    public IBuilder<TEntity> WithRecursionLevel(int recursionLevel)
    {
        _context.With.RecursionLevel.SetAllowedRecursionLevel(recursionLevel);
        return this;
    }

    public IBuilder<TEntity> WithStringPrefix(string prefix)
    {
        _context.With.String.Prefix = prefix;
        return this;
    }

    public IBuilder<TEntity> WithStringSuffix(string suffix)
    {
        _context.With.String.Suffix = suffix;
        return this;
    }

    public IBuilder<TEntity> WithStartingNumber(int startingNumber)
    {
        _context.With.Number.StartingNumber = startingNumber;
        return this;
    }

    public IBuilder<TEntity> WithLogger(ILogger logger)
    {
        if(logger != null)
        {
            _context.With.Log.Logger = logger;
        }

        return this;
    }

    object IBuilder.Build()
    {
        return Build();
    }
}
