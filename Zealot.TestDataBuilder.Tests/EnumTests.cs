using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class EnumTests
{
    [Fact]
    public void Support_Enum()
    {
        var entity = TestDataBuilder
            .For<EnumPropClass>()
            .Build();

        entity.EnumHavingOneValueProp.Should().Be(EnumHavingOneValue.FirstValue);
    }
}