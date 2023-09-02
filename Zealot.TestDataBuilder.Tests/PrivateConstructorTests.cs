using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class PrivateConstructorTests
{
    [Fact]
    public void No_support_for_a_class_with_private_constructor()
    {
        var entity = TestDataBuilder
            .For<ClassWithPrivateConstructor>()
            .Build();

        entity.Should().BeNull();
    }
}
