namespace Zealot.SampleBuilder.Tests.TestObjects;

internal enum EnumHavingOneValue
{
     FirstValue = 1
}
internal enum EnumHavingNoValue { }

internal enum EnumHavingMultipleValues
{
     item1,
     item2,
     item3
}

internal class EnumHavingOneValueClass
{
     public EnumHavingOneValue EnumHavingOneValueProp { get; set; }
}

internal class EnumHavingNoValueClass
{
     public EnumHavingNoValue EnumHavingNoValueProp { get; set; }
}

internal class EnumHavingOneValueNullableClass
{
     public EnumHavingOneValue? EnumHavingOneValueNullableProp { get; set; }
}

internal class EnumHavingMultipleValuesClass
{
     public EnumHavingMultipleValues EnumHavingMultipleValuesProp { get; set; }
}
