﻿using System.Text;

namespace Zealot.Internals.Strategies;

internal class StringStrategy : IStrategy
{
    private int _number;

    public Expression<Func<Type, bool>> ResolveCondition => t => t == typeof(string);

    public object Execute(IContext context)
    {
        var sb = new StringBuilder();
        sb.Append(context.With.String.Prefix);
        sb.Append(context.With.String.Body.IsSet 
            ? context.With.String.Body.Value 
            : context.Scope.ParentPropertyName);
        sb.Append('_');
        sb.Append(++_number);
        sb.Append(context.With.String.Suffix);
        
        return sb.ToString();
    }
}
