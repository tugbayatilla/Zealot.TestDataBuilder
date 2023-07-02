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
    
}