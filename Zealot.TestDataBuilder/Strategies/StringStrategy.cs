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

    public override void Execute(IContext context) //todo: change this logic.
    {
        var pi = context.Scope.Entity.GetType().GetProperty(context.Scope.PropertyName);
        
        if (pi.GetValue(context.Scope.Entity) != default) return;
        
        var value = $"{context.With.String.Prefix}{pi.Name}{context.With.String.Suffix}";
        pi.SecureSetValue(context.Scope.Entity, value);
    }
}
