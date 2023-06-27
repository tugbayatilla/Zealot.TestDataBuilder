using System.Linq.Expressions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

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
    
    public static void CheckAllWithSetOnly<TProperty>(object obj)
    {
        CheckAllWithSetOnly(obj, typeof(TProperty));
    }
    
    public static void CheckAllWithSetOnly(object obj, Type setOnlyType)
    {
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            if(prop.PropertyType == setOnlyType)
                prop.GetValue(obj).Should().NotBe(prop.IsNullable() ? default : prop.PropertyType.GetDefault());
            else
            {
                prop.GetValue(obj).Should().Be(prop.IsNullable() ? default : prop.PropertyType.GetDefault());
            }
        }
    }
}