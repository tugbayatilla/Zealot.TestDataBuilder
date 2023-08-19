using Microsoft.Extensions.Logging;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals;

internal class TestDataBuilder<TEntity> : ITestDataBuilder<TEntity>
{
    private readonly IContext _context;

    public TestDataBuilder(IContext context)
    {
        _context = context;
    }

    public TEntity Build()
    {
        _context.With.Log.Logger.LogDebug("{ExecuteName} for {EntityType} starts", nameof(Build),
            _context.Scope.EntityType.Name);

        var strategy = _context.StrategyContainer.Resolve(_context.Scope.EntityType);
        return (TEntity) strategy.Execute(_context);
    }

    public ITestDataBuilder<TEntity> WithOnly<TProperty>()
    {
        return WithOnly(typeof(TProperty));
    }

    public ITestDataBuilder<TEntity> WithOnly(Type type)
    {
        _context.With.Only.Add(type);
        return this;
    }


    public ITestDataBuilder<TEntity> WithOverride(Action<TEntity> action)
    {
        _context.With.Override.Add(o => action.Invoke((TEntity) o));
        return this;
    }

    public ITestDataBuilder<TEntity> WithDate(DateTime dateTime)
    {
        _context.With.Date.UtcDate = dateTime;
        return this;
    }

    public ITestDataBuilder<TEntity> WithGuid(Guid guid)
    {
        _context.With.Guid.Guid = guid;
        return this;
    }

    public ITestDataBuilder<TEntity> WithRecursionLevel(int recursionLevel)
    {
        _context.With.RecursionLevel.SetAllowedRecursionLevel(recursionLevel);
        return this;
    }

    public ITestDataBuilder<TEntity> WithStringPrefix(string prefix)
    {
        _context.With.String.Prefix = prefix;
        return this;
    }

    public ITestDataBuilder<TEntity> WithStringSuffix(string suffix)
    {
        _context.With.String.Suffix = suffix;
        return this;
    }

    public ITestDataBuilder<TEntity> WithStartingNumber(int startingNumber)
    {
        _context.With.Number.StartingNumber = startingNumber;
        return this;
    }

    public ITestDataBuilder<TEntity> WithLogger(ILogger logger)
    {
        if (logger != null)
        {
            _context.With.Log.Logger = logger;
        }

        return this;
    }

    public ITestDataBuilder<TEntity> WithListSize(int size)
    {
        _context.With.List.Size = size;
        return this;
    }
}
