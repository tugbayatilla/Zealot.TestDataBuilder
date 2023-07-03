using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ClassTests
{
    [Fact]
    public void Support_class()
    {
        var entity = TestDataBuilder
            .For<PublicClass>()
            .Build();

        entity.PublicWithAllProp.Should().NotBeNull();
    }
    
    
}
