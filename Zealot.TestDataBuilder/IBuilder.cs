namespace Zealot;

public interface IBuilder<out TEntity> where TEntity: new()
{
    TEntity Build();
    IBuilder<TEntity> SetOnly<TProperty>();
}