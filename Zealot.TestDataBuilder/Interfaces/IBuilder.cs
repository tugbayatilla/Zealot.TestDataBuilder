using Microsoft.Extensions.Logging;
using Zealot.Strategies;

namespace Zealot.Interfaces;

public interface IBuilder<out TEntity>
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
    IBuilder<TEntity> WithOverride(Action<TEntity> action);

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
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithStringSuffix(string suffix);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithStartingNumber(int startingNumber);
    
    /// <summary>
    /// Optional
    /// </summary>
    IBuilder<TEntity> WithLogger(ILogger logger);
}
