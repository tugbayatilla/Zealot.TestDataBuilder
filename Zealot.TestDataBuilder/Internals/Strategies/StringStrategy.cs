using System.Text;

namespace Zealot.Internals.Strategies;

internal class StringStrategy : IStrategy
{
    private int _number;
    private static readonly string DefaultSeparator = "_";
    public Expression<Func<Type, bool>> ResolveCondition => t => t == typeof(string);

    public object Execute(IContext context)
    {
        var sb = new StringBuilder();
        sb.Append(context.With.String.Prefix);
        
        sb.Append(context.With.String.Body.IsSet 
            ? context.With.String.Body.Value 
            : context.Scope.ParentPropertyName);
        
        sb.Append(context.With.String.Separator.IsSet ?
            context.With.String.Separator.Value
            : DefaultSeparator);
        
        sb.Append(context.With.String.StringUniqueStartNumber.IsSet ?
            context.With.String.StringUniqueStartNumber.Value++
            : ++_number);
        
        sb.Append(context.With.String.Suffix);
        
        return sb.ToString();
    }
}
