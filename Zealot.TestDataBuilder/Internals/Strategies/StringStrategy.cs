using System.Text;

namespace Zealot.Internals.Strategies;

internal class StringStrategy : IStrategy
{
    private static readonly string DefaultSeparator = "";
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
        
        if(context.With.String.StringUniqueStartNumber.IsSet)
        {
            sb.Append(context.With.String.StringUniqueStartNumber.Value++);
        }

        sb.Append(context.With.String.Suffix);
        
        return sb.ToString();
    }
}
