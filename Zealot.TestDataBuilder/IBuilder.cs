namespace Zealot;

public interface IBuilder<TEntity> where TEntity: new()
{
    TEntity Build();
}