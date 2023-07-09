using System.Linq.Expressions;
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
        
        if (type == null) throw new ArgumentNullException("type");
        
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
        return type.IsValueType && !type.IsPrimitive && !type.IsEnum;
    }

    public static void SecureSetValue(this PropertyInfo propertyInfo, object entity, object value)
    {
        if (propertyInfo.GetSetMethod() != null)
        {
            propertyInfo.SetValue(entity, value);
        }
    }
}