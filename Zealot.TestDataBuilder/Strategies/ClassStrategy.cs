using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override void SetValue(IContext context, PropertyInfo propertyInfo)
    {
        if (!context.WithRecursionLevel.CanContinueDeeper(propertyInfo.PropertyType))
            return;
        
        base.SetValue(context, propertyInfo);
    }

    public override Expression<Func<Type, bool>> ResolveCondition => info => info.IsClass || info.IsStruct();
    public override object GenerateValue(IContext context, Type type)
    {
        var instance = Instance.Create(type);
        return instance.WithContext(context).Build();
    }
}
