using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

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
    
    [Fact]
    public void Support_recursion_with_recursion_level_1()
    {
        var entity = TestDataBuilder
            .For<ClassWithClassBRecursively>()
            .WithRecursionLevel(1)
            .Build();

        entity.Prop.Prop.Should().NotBeNull();
        entity.Prop.Prop.Prop.Should().NotBeNull();
        entity.Prop.Prop.Prop.Prop.Should().BeNull();
    }
}
