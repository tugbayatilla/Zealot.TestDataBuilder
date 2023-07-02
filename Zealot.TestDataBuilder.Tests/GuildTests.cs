using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class GuidTests
{
    [Fact]
    public void Support_guid()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<PublicGuid>()
            .WithGuid(guid)
            .Build();

        entity.GuidProp.Should().Be(guid);
    }
    
    [Fact]
    public void Support_guid_not_empty_as_default()
    {
        var entity = TestDataBuilder
            .For<PublicGuid>()
            .Build();

        entity.GuidProp.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Support_guid_nullable()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<PublicGuidNullable>()
            .WithGuid(guid)
            .Build();

        entity.GuidNullableProp.Should().Be(guid);
    }
    
    [Fact]
    public void Support_guid_nullable_not_empty_as_default()
    {
        var entity = TestDataBuilder
            .For<PublicGuidNullable>()
            .Build();

        entity.GuidNullableProp.Should().NotBeEmpty();
    }
}
