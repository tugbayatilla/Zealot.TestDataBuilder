using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class StringStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[] { typeof(string) };

    public override object GenerateValue(IContext context, Type type)
    {
        Thread.Sleep(1);
        return DateTime.Now.ToString("ddMMyyyyhhmmssfffff");
    }

    public override void SetValue(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, propertyInfo.Name);
    }
}
