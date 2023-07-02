using System.Linq.Expressions;
using System.Reflection;
using Zealot.Strategies;

namespace Zealot;

internal class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;
    private readonly List<(MemberExpression member, object value)> _overrideExpressions = new();

    public Builder(IContext context)
    {
        _context = context;
    }

    public TEntity Build()
    {
        // find properties
        var properties = _context.Entity.GetType().GetProperties();
        // for each property
        foreach (var propertyInfo in properties)
        {
            if (_context.WithOnlyContainer.IgnoreThis(propertyInfo.PropertyType)) continue;
            
            // find the Strategy for the type
            var strategy = _context.StrategyContainer.Resolve(propertyInfo);
            // execute the strategy
            // TODO: parallelism 
            Task.Run(() => strategy.ExecuteAsync(_context, propertyInfo)).Wait();
        }

        // override values
        _overrideExpressions.ForEach(p =>
        {
            ((PropertyInfo)p.member.Member).SetValue(_context.Entity, p.value);
        });
        
        
        return (TEntity)_context.Entity;
    }

    public IBuilder<TEntity> WithOnly<TProperty>()
    {
        return WithOnly(typeof(TProperty));
    }

    public IBuilder<TEntity> WithOnly(Type type)
    {
        _context.WithOnlyContainer.Add(type);
        return this;
    }

    public IBuilder<TEntity> WithValue<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value)
    {
        if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));
        if (value == null) throw new ArgumentNullException(nameof(value));

        if (propertySelector.Body is MemberExpression propertySelectorBody)
        {
            _overrideExpressions.Add(new (propertySelectorBody, value));    
        }
        
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
}