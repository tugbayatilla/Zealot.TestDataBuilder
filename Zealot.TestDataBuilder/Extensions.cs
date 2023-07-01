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

    public static bool IsSame(this Type p, Type type) =>
        p.IsEquivalentTo(type)
        || (p.IsGenericType == type.IsGenericType && !p.GenericTypeArguments.Except(type.GenericTypeArguments).Any());
    
    public static bool IsNullableEnum(this Type t)
    {
        var u = Nullable.GetUnderlyingType(t);
        return u is {IsEnum: true};
    }
}