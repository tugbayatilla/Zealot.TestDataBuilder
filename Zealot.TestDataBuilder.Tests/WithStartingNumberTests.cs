using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithStartingNumberTests
{
    [Fact]
    public void WithStartingNumber_is_5()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithStartingNumber(5)
            .Build();

        entity.Prop1.Should().Be(5);
        entity.Prop2.Should().Be(6);
    }
}
