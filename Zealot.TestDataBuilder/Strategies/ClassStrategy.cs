using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override void Execute(IContext context)
    {
        var pi = context.Entity.GetType().GetProperty(context.PropertyName);
        
        if (!context.With.RecursionLevel.CanContinueDeeper(context, pi.PropertyType))
            return;
        
        base.Execute(context);
    }

    public override Expression<Func<Type, bool>> ResolveCondition => info => 
        (info.IsClass || info.IsStruct()) 
        && !info.IsArray
        && !new ListStrategy().ResolveCondition.Compile().Invoke(info);
    
    public override object GenerateValue(IContext context, Type type)
    {
        return TestDataBuilder.WithContext(type, context).Build()!;
    }
}
