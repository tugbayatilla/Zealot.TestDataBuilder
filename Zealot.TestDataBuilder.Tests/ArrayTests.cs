using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ArrayTests
{
    [Fact]
    public void Support_StringArray()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoStringArray>()
            .Build();

        entity.Prop1.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_ByteArray()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoByteArray>()
            .Build();

        entity.Prop1.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IntArray()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoIntegerArray>()
            .Build();

        entity.Prop1.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_BooleanArray()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoBoolArray>()
            .WithOverride(p=>p.Prop1[0] = true)
            .Build();

        entity.Prop1.Should().NotBeNull();
        entity.Prop1.Length.Should().Be(2);
        entity.Prop1[0].Should().BeTrue();

    }
    
    [Fact]
    public void Support_EnumArray()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneEnumWithTreeItemArray>()
            .Build();

        entity.Prop1.Should().NotBeNull();
    }
}