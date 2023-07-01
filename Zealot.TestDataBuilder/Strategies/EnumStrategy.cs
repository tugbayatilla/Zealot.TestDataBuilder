using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

public class EnumStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var tempEnum = Enum.GetValues(propertyInfo.PropertyType);
        if (tempEnum.Length > 0)
        {
            var value = tempEnum.GetValue(0);
            propertyInfo.SetValue(context.Entity, value);
        }
        
        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => default!;

    public override Expression<Func<PropertyInfo, bool>> ResolveCondition => 
        info => info.PropertyType.IsEnum || (info.PropertyType.BaseType != null && info.PropertyType.BaseType == typeof(Enum));
}