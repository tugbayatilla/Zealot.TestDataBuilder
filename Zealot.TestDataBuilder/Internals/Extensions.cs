using System.Reflection;

namespace Zealot.Internals;

internal static class Extensions
{
    public static bool IsNullable(this PropertyInfo p)
    {
        return new NullabilityInfoContext().Create(p).WriteState is NullabilityState.Nullable;
    }

    public static bool IsNullable(this Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }

    public static object GetDefault(this Type type)
    {
        Expression<Func<object>> e = Expression.Lambda<Func<object>>(
            Expression.Convert(
                Expression.Default(type), typeof(object)
            )
        );

        return e.Compile()();
    }

    public static bool IsSame(this Type p, Type type) =>
        p.IsEquivalentTo(type)
        || (p.IsGenericType == type.IsGenericType && !p.GenericTypeArguments.Except(type.GenericTypeArguments).Any());

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
