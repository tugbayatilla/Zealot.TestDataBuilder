using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class RecursionTests
{
    // todo: check for struct recursion as well
    [Fact]
    public void Support_recursion_1()
    {
        var guid = Guid.NewGuid();
        var entity = TestDataBuilder
            .For<PublicRecursionAClass>()
            .WithGuid(guid)
            .Build();

        entity.PublicRecursionBProp.PublicRecursionAClassProp.Should().BeNull();
    }
    
    
}
