using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class EnumStrategy : Strategy
{
    public override void SetValue(IContext context, PropertyInfo propertyInfo)
    {
        var tempEnum = (Array)GenerateValue(context, propertyInfo.PropertyType);
        if (tempEnum.Length > 0)
        {
            var value = tempEnum.GetValue(0);
            propertyInfo.SetValue(context.Entity, value);
        }
    }

    public override Expression<Func<Type, bool>> ResolveCondition => 
        info => info.IsEnum 
                || info.IsNullableEnum() 
                || (info.BaseType != null && info.BaseType == typeof(Enum));

    public override object GenerateValue(IContext context, Type type)
    {
        var enumType = type;
        if (type.IsNullableEnum())
        {
            enumType = Nullable.GetUnderlyingType(type);
        }
        
        return Enum.GetValues(enumType!);
    }
}
