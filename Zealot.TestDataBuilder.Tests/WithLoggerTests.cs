using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithLoggerTests
{
    [Fact]
    public void Null_value_will_be_ignored()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithLogger(null!)
            .Build();

        entity.Should().NotBeNull();
    }

    
}
