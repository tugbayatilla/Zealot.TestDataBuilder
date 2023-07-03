using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class StructStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => info => info.IsStruct() && false;
    public override object GenerateValue(IContext context, Type type)
    {
        return null;
    }
}
