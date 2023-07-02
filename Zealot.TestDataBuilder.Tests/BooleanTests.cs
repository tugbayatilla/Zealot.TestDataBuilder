using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class BooleanTests
{
    [Fact]
    public void Support_bool()
    {
        var entity = TestDataBuilder
            .For<PublicBool>()
            .Build();

        entity.BoolProp.Should().Be(false);
    }
}