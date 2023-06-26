using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StringTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder.For<PublicWithOneString>().Build();
        entity.StringProp.Should().Be($"{nameof(entity.StringProp)}");
    }
}
