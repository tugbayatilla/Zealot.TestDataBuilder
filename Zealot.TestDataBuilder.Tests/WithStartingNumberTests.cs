using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithStartingNumberTests
{
    [Fact]
    public void WithStartingNumber_is_5()
    {
        var entity = TestDataBuilder
            .For<IntPropertyClass>()
            .WithStartingNumber(5)
            .Build();

        entity.IntProp.Should().Be(5);
        entity.IntProp2.Should().Be(6);
    }

    
}
