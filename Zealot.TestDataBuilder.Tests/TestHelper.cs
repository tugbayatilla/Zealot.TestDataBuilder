using System.Linq.Expressions;

namespace Zealot.SampleBuilder.Tests;

public static class TestHelper
{
    /// <summary>
    /// Check every property in object if they are default except given property types
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="TProperty"></typeparam>
    public static void CheckDefaultExcept<TProperty>(object obj)
    {
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            if(prop.PropertyType == typeof(TProperty)) continue;
            
            prop.GetValue(obj).Should().Be(prop.IsNullable() ? default : prop.PropertyType.GetDefault());
        }
    }
    
    public static void CheckNotDefault<TProperty>(object obj)
    {
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            if(prop.PropertyType != typeof(TProperty)) continue;
            
            prop.GetValue(obj).Should().Be(prop.IsNullable() ? default : prop.PropertyType.GetDefault());
        }
    }
}