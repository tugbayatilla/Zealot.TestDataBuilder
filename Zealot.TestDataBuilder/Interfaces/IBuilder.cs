using Zealot.Strategies;

namespace Zealot.Interfaces;

internal interface IBuilder
{
    object Build();
}

public interface IBuilder<TEntity>
    where TEntity: new() 
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
    IBuilder<TEntity> WithValue(Action<TEntity> action);

    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithDate(DateTime dateTime);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithStrategy(IStrategy strategy);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithGuid(Guid guid);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithRecursionLevel(int recursionLevel);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithStringPrefix(string prefix);
    
    IBuilder<TEntity> WithStringSuffix(string suffix);
}