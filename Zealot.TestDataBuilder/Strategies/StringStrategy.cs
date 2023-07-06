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
        return _number.ToString();
    }

    public override void Execute(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SecureSetValue(context.Entity, propertyInfo.Name);
    }
}
