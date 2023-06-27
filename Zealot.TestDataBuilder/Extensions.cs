using System.Reflection;

namespace Zealot;

public static class Extensions
{
    public static bool IsNullable(this PropertyInfo p)
    {
        return new NullabilityInfoContext().Create(p).WriteState is NullabilityState.Nullable;
    }
    
    public static bool IsNullable(this Type type)
    {
        // ref-type
        if (!type.IsValueType)
        {
            return true; 
        }

        // Nullable<T>
        return Nullable.GetUnderlyingType(type) != null;
    }

    public static object? GetDefault(this Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}