using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override void Execute(IContext context, PropertyInfo propertyInfo)
    {
        if (!context.WithRecursionLevel.CanContinueDeeper(context, propertyInfo.PropertyType))
            return;
        
        base.Execute(context, propertyInfo);
    }

    public override Expression<Func<Type, bool>> ResolveCondition => info => 
        (info.IsClass || info.IsStruct()) 
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);
    
    public override object GenerateValue(IContext context, Type type)
    {
        var instance = Instance.Create(type);
        return instance?.WithContext(context).Build()!;
    }
}
