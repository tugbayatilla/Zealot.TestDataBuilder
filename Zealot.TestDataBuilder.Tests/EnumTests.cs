using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class EnumTests
{
    [Fact]
    public void Support_Enum_one_value()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneEnumWithOneItem>()
            .Build();

        entity.Prop.Should().Be(EnumWithOneItem.Item1);
    }
    
    [Fact]
    public void Support_Enum_no_value()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneEnumWithNothing>()
            .Build();

        entity.Prop.Should().Be(default);
    }
    
    [Fact]
    public void Support_Enum_nullable()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneEnumWithOneItemNullable>()
            .Build();

        entity.Prop.Should().Be(EnumWithOneItem.Item1);
    }
    
    [Fact]
    public void Support_Enum_multiple_values()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneEnumWithThreeItem>()
            .Build();

        entity.Prop.Should().Be(EnumWithThreeItem.Item1);
        entity.Prop.Should().NotBe(EnumWithThreeItem.Item2);
        entity.Prop.Should().NotBe(EnumWithThreeItem.Item3);
    }
}
