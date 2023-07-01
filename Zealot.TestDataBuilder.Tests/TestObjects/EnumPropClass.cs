namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class EnumPropClass
{
    public EnumHavingOneValue EnumHavingOneValueProp { get; set; }
}

internal enum EnumHavingOneValue
{
    FirstValue = 1
}