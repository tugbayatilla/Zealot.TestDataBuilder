using System.Reflection;

namespace Zealot.Internals;

internal static class Extensions
{
    public static bool IsNullable(this Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }

    public static bool IsSame(this Type p, Type type)
    {
        var result = p.Name == type.Name;
        if (!result) return false;
        
        return p.IsGenericType == type.IsGenericType &&
               !p.GenericTypeArguments.Except(type.GenericTypeArguments).Any();
    }

    public static bool IsNullableEnum(this Type type)
    {
        var u = Nullable.GetUnderlyingType(type);
        return u is {IsEnum: true};
    }

    public static bool IsStruct(this Type type)
    {
        return type is {IsValueType: true, IsPrimitive: false, IsEnum: false};
    }

    public static void SecureSetValue(this PropertyInfo propertyInfo, object entity, object value)
    {
        if (propertyInfo.GetSetMethod() != null)
        {
            propertyInfo.SetValue(entity, value);
        }
    }
}
