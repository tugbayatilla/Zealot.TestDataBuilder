using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class RecursionTests
{
    // todo: check for struct recursion as well
    [Fact]
    public void Support_recursion_with_default_level_0()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<PublicRecursionAClass>()
            .Build();

        entity.PublicRecursionBProp.PublicRecursionAClassProp.Should().BeNull();
    }
    
    [Fact]
    public void Support_recursion_with_recursion_level_1()
    {
        var entity = TestDataBuilder
            .For<PublicRecursionAClass>()
            .WithRecursionLevel(1)
            .Build();

        entity.PublicRecursionBProp.PublicRecursionAClassProp.Should().NotBeNull();
        entity.PublicRecursionBProp.PublicRecursionAClassProp.PublicRecursionBProp.Should().NotBeNull();
        entity.PublicRecursionBProp.PublicRecursionAClassProp.PublicRecursionBProp.PublicRecursionAClassProp.Should().BeNull();
    }
    
    
}
