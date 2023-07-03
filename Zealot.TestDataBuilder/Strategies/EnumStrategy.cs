using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class EnumStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var type = propertyInfo.PropertyType;
        if (propertyInfo.PropertyType.IsNullableEnum())
        {
            type = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
        }
        
        var tempEnum = Enum.GetValues(type!);
        if (tempEnum.Length > 0)
        {
            var value = tempEnum.GetValue(0);
            propertyInfo.SetValue(context.Entity, value);
        }
        
        await Task.CompletedTask;
    }

    public override Expression<Func<PropertyInfo, bool>> ResolveCondition => 
        info => info.PropertyType.IsEnum 
                || info.PropertyType.IsNullableEnum() 
                || (info.PropertyType.BaseType != null && info.PropertyType.BaseType == typeof(Enum));
}
