using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ArrayStrategy : Strategy
{
    public override Expression<Func<Type, bool>> ResolveCondition => info => info.IsArray;
    public override object GenerateValue(IContext context, Type type)
    {
        var instanceType = type;

        if (type is {IsInterface: true, IsGenericType: true})
        {
            instanceType = typeof(List<>).MakeGenericType(type.GenericTypeArguments);
        }

        return Instance.Create(instanceType);
    }
}
