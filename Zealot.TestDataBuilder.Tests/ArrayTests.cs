using Zealot.SampleBuilder.Tests.TestObjects.ArrayTestClasses;

namespace Zealot.SampleBuilder.Tests;

public class ArrayTests
{
    [Fact]
    public void Support_StringArray()
    {
        var entity = TestDataBuilder
            .For<StringArrayTestClass>()
            .Build();

        entity.StringArrayProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_ByteArray()
    {
        var entity = TestDataBuilder
            .For<ByteArrayTestClass>()
            .Build();

        entity.ByteArrayProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IntArray()
    {
        var entity = TestDataBuilder
            .For<IntArrayTestClass>()
            .Build();

        entity.IntArrayProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_BooleanArray()
    {
        var entity = TestDataBuilder
            .For<BooleanArrayTestClass>()
            .WithValue(p=>p.BooleanArrayProp[0] = true)
            .Build();

        entity.BooleanArrayProp.Should().NotBeNull();
        entity.BooleanArrayProp.Length.Should().Be(2);
        entity.BooleanArrayProp[0].Should().BeTrue();

    }
    
    [Fact]
    public void Support_EnumArray()
    {
        var entity = TestDataBuilder
            .For<EnumArrayTestClass>()
            .Build();

        entity.EnumArrayProp.Should().NotBeNull();
    }
}