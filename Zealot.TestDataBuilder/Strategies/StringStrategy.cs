using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class StringStrategy : Strategy
{
    private int _number;
    public override IEnumerable<Type> AvailableTypes => new[] { typeof(string) };

    public override object GenerateValue(IContext context, Type type)
    {
        _number++;
        return $"{context.With.String.Prefix}{context.Scope.PropertyName}_{_number}{context.With.String.Suffix}";
    }

    public override object ExecuteWithReturn(IContext context)
    {
        _number++;
        return $"{context.With.String.Prefix}{context.Scope.PropertyName}_{_number}{context.With.String.Suffix}";
    }
}
