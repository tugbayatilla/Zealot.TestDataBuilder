using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ClassTests
{
    [Fact]
    public void Support_class()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneClassWithAllPrimitives>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    
}
