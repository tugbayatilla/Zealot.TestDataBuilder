using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class GuidTests
{
    [Fact]
    public void Support_guid()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<ClassWithTwoGuid>()
            .WithGuid(guid)
            .Build();

        entity.Prop1.Should().Be(guid);
    }
    
    [Fact]
    public void Support_guid_not_empty_as_default()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoGuid>()
            .Build();

        entity.Prop1.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Support_guid_nullable()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<ClassWithTwoGuidNullable>()
            .WithGuid(guid)
            .Build();

        entity.Prop1.Should().Be(guid);
    }
    
    [Fact]
    public void Support_guid_nullable_not_empty_as_default()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoGuidNullable>()
            .Build();

        entity.Prop1.Should().NotBeEmpty();
    }
}
