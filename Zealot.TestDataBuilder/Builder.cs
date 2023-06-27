using System.Linq.Expressions;
using System.Reflection;

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
            if (_context.WithOnlyContainer.IgnoreThis(propertyInfo.PropertyType)) continue;
            
            // find the Strategy for the type
            var strategy = _strategyContainer.Resolve(propertyInfo.PropertyType);
            // execute the strategy
            // TODO: parallelism 
            Task.Run(() => strategy.ExecuteAsync(_context, propertyInfo)).Wait();
        }

        // override values
        overrideExpressions.ForEach(p =>
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

    private List<(MemberExpression member, object value)> overrideExpressions = new();
    public IBuilder<TEntity> WithValue<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value)
    {
        if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));
        
        overrideExpressions.Add(new (propertySelector.Body as MemberExpression, value));
        return this;
    }
}