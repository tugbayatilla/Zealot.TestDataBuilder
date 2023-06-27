using System.Linq.Expressions;

namespace Zealot;

public interface IBuilder<TEntity> where TEntity: new()
{
    /// <summary>
    /// Required
    /// </summary>
    TEntity Build();
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithOnly<TProperty>();
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithOnly(Type type);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithValue<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value);
}