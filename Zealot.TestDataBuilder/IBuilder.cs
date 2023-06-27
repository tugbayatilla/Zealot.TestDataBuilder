using System.Linq.Expressions;

namespace Zealot;

public interface IBuilder<TEntity> where TEntity: new()
{
    TEntity Build();
    IBuilder<TEntity> SetOnly<TProperty>();
    IBuilder<TEntity> SetOnly(Type type);
    IBuilder<TEntity> SetValue<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value);
}