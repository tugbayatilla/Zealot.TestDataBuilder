using Microsoft.Extensions.Logging;

namespace Zealot;

public interface ITestDataBuilder<out TEntity>
{
    /// <summary>
    /// Required
    /// </summary>
    TEntity Build();
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithOnly<TProperty>();
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithOnly(Type type); 
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithOverride(Action<TEntity> action);

    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithDate(DateTime dateTime);

    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithGuid(Guid guid);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithRecursionLevel(int recursionLevel);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithStringPrefix(string prefix);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithStringSuffix(string suffix);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithStartingNumber(int startingNumber);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithLogger(ILogger logger);
    
    /// <summary>
    /// Optional
    /// </summary>
    ITestDataBuilder<TEntity> WithListSize(int size);

}
