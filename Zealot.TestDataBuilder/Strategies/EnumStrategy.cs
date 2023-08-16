using System.Linq.Expressions;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class EnumStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => 
        info => info.IsEnum 
                || info.IsNullableEnum() 
                || (info.BaseType != null && info.BaseType == typeof(Enum));

    public override object Execute(IContext context)
    {
        var type = context.Scope.EntityType;
        var enumType = type;
        if (type.IsNullableEnum())
        {
            enumType = Nullable.GetUnderlyingType(type);
        }
        
        var values = Enum.GetValues(enumType!);
        return values.Length > 0 ? values.GetValue(0)! : default!;
    }
}
