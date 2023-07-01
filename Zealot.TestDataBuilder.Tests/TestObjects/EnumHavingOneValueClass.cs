namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class EnumHavingOneValueClass
{
    public EnumHavingOneValue EnumHavingOneValueProp { get; set; }
}

internal enum EnumHavingOneValue
{
    FirstValue = 1
}
