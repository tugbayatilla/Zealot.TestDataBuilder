using System.Linq.Expressions;

namespace Zealot;

public interface IBuilder<TEntity> where TEntity: new()
{
    TEntity Build();
    IBuilder<TEntity> WithOnly<TProperty>();
    IBuilder<TEntity> WithOnly(Type type);
    IBuilder<TEntity> WithValue<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value);
}