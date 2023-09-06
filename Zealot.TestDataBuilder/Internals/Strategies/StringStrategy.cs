using System.Text;

namespace Zealot.Internals.Strategies;

internal class StringStrategy : IStrategy
{
    public Expression<Func<Type, bool>> ResolveCondition => t => t == typeof(string);

    public object Execute(IContext context)
    {
        var sb = new StringBuilder();
        
        sb.Append(context.With.String.Body.IsSet 
            ? context.With.String.Body.Value 
            : TestDataBuilder.DefaultStringBodyTemplate);
        
        sb.Append(context.With.String.StringUniqueStartingNumber.Value);
        IncrementTheNumber(context);
        
        return sb.ToString();
    }

    private static void IncrementTheNumber(IContext context)
    {
        var nextNumber = context.With.String.StringUniqueStartingNumber.Value + 1;
        context.With.String.StringUniqueStartingNumber.Set(nextNumber);
    }
}
