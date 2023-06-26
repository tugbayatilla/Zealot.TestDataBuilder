using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StringTests
{
    [Fact]
    public void GIVEN_PublicWithOneString_WHEN_Build_called_THEN_StringProp_is_StringProp()
    {
        var entity = TestDataBuilder.For<PublicWithOneString>().Build();
        entity.StringProp.Should().Be($"{nameof(entity.StringProp)}");
    }
}
