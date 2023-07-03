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

    public override void SetValue(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, propertyInfo.Name);
    }
}
