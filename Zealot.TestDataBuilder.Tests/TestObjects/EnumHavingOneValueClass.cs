namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class EnumHavingOneValueClass
{
    public EnumHavingOneValue EnumHavingOneValueProp { get; set; }
}

public enum EnumHavingOneValue
{
    FirstValue = 1
}
