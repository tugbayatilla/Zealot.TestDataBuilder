using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ArrayTests
{
    [Fact]
    public void Support_StringArray()
    {
        var entity = TestDataBuilder
            .For<StringArrayClass>()
            .Build();

        entity.StringArrayProp.Should().NotBeNull();
    }
}