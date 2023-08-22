using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class BooleanTests
{
    [Fact]
    public void Support_bool()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoBool>()
            .Build();

        entity.Prop.Should().Be(true);
    }
    
    [Fact]
    public void Support_bool_nullable()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoBoolNullable>()
            .Build();

        entity.Prop1.Should().Be(true);
        entity.Prop2.Should().Be(true);
    }
}
