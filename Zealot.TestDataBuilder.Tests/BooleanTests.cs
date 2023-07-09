using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class BooleanTests
{
    [Fact]
    public void Support_bool()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoBool>()
            .Build();

        entity.Prop.Should().Be(false);
    }
    
    [Fact]
    public void Support_bool_nullable()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoBoolNullable>()
            .Build();

        entity.Prop1.Should().Be(false);
    }
}
