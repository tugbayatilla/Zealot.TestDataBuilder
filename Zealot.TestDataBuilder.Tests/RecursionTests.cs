using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class RecursionTests
{
    [Fact]
    public void Support_recursion_with_default_level_0()
    {
        var entity = TestDataBuilder
            .For<ClassWithClassBRecursively>()
            .Build();

        entity.Prop.Prop.Should().BeNull();
    }
}
