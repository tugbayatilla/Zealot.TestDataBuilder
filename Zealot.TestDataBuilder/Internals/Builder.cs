using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Strategies;

namespace Zealot.Internals;

internal class Builder<TEntity> : IBuilder<TEntity>
    where TEntity : new()
{
    private readonly IContext _context;
    private readonly List<(MemberExpression member, object value)> _overrideExpressions = new();

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
            var strategy = _context.StrategyContainer.Resolve(propertyInfo);
            // execute the strategy
            Task.Run(() => strategy.ExecuteAsync(_context, propertyInfo)).Wait();
        }

        // override values
        _overrideExpressions.ForEach(p =>
        {
            var prop = ((PropertyInfo) p.member.Member);
            if (prop.ReflectedType == _context.Entity.GetType())
            {
                prop.SetValue(_context.Entity, p.value);
            }
            else
            {
                // get value of property of property
                var propertyInstance = _context.Entity.GetType().GetRuntimeProperty(prop.ReflectedType.Name)
                    .GetValue(_context.Entity);

                //change value of property of property
                propertyInstance.GetType().GetRuntimeProperty(prop.Name).SetValue(propertyInstance, p.value);
                
                // set property to property of propery
                _context.Entity.GetType().GetRuntimeProperty(prop.ReflectedType.Name).SetValue(_context.Entity, propertyInstance);
            }
        });
        
        
        return (TEntity)_context.Entity;
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

    public IBuilder<TEntity> WithRecursionLevel(int recursionLevel)
    {
        _context.WithRecursionLevel.SetAllowedRecursionLevel(recursionLevel);
        return this;
    }
}