using System.Text;

namespace Zealot.Internals.Strategies;

internal class StringStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition => t => t == typeof(string);

    public object Execute(IContext context)
    {
        if (context.With.Default.IsUsingDefault)
            return default!;
        
        var sb = new StringBuilder();
        
        sb.Append(context.With.String.Body);
        sb.Append(context.With.String.StringUniqueStartingNumber++);
        
        return sb.ToString();
    }
}
