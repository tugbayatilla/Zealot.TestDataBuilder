using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ClassTests
{
    [Fact]
    public void Support_class()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneClassWithTwoInteger>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
}
