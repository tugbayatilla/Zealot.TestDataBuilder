using Microsoft.Extensions.Logging;
using Zealot.Interfaces;
using Zealot.Strategies;

namespace Zealot.Internals;

internal class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;

    public Builder(IContext context)
    {
        _context = context;
    }

    public TEntity Build()
    {
        _context.With.Log.Logger.LogDebug("{ExecuteName} for {EntityType} starts", nameof(Build),
            _context.Scope.EntityType.Name);

        var strategy = _context.StrategyContainer.Resolve(_context.Scope.EntityType);
        strategy.Execute(_context);

        _context.Scope = _context.Scope with { PropertyName = ""};
        return (TEntity) _context.Scope.Entity;
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


    public IBuilder<TEntity> WithOverride(Action<TEntity> action)
    {
        _context.With.Override.Add(o => action.Invoke((TEntity) o));
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
        if (logger != null)
        {
            _context.With.Log.Logger = logger;
        }

        return this;
    }

    public IBuilder<TEntity> WithListSize(int size)
    {
        _context.With.List.Size = size;
        return this;
    }
}
