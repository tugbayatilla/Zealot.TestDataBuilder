using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class StringStrategy : Strategy
{
    private int _number;
    public override IEnumerable<Type> AvailableTypes => new[] { typeof(string) };

    public override object GenerateValue(IContext context, Type type)
    {
        _number++;
        return $"{context.With.String.Prefix}{_number}{context.With.String.Suffix}";
    }

    public override void Execute(IContext context, PropertyInfo propertyInfo)
    {
        if (propertyInfo.GetValue(context.Entity) != default) return;
        
        var value = $"{context.With.String.Prefix}{propertyInfo.Name}{context.With.String.Suffix}";
        propertyInfo.SecureSetValue(context.Entity, value);
    }
}
