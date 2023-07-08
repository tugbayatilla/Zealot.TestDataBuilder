using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class EnumTests
{
    [Fact]
    public void Support_Enum_one_value()
    {
        var entity = TestDataBuilder
            .For<EnumHavingOneValueClass>()
            .Build();

        entity.EnumHavingOneValueProp.Should().Be(EnumHavingOneValue.FirstValue);
    }
    
    [Fact]
    public void Support_Enum_no_value()
    {
        var entity = TestDataBuilder
            .For<EnumHavingNoValueClass>()
            .Build();

        entity.EnumHavingNoValueProp.Should().Be(default);
    }
    
    [Fact]
    public void Support_Enum_nullable()
    {
        var entity = TestDataBuilder
            .For<EnumHavingOneValueNullableClass>()
            .Build();

        entity.EnumHavingOneValueNullableProp.Should().Be(EnumHavingOneValue.FirstValue);
    }
    
    [Fact]
    public void Support_Enum_multiple_values()
    {
        var entity = TestDataBuilder
            .For<EnumHavingMultipleValuesClass>()
            .Build();

        entity.EnumHavingMultipleValuesProp.Should().Be(EnumHavingMultipleValues.item1);
    }
}
