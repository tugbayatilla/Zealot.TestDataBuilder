    

using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithRecursionTests
{
    [Fact]
    public void Should_be_recursive_list_property_must_be_filled()
    {
        var p1 = TestDataBuilder
            .For<ClassWithSelfListRecursively>()
            .WithRecursionLevel(4)
            .Build();
        
        p1.Should().NotBeNull();
        p1.Self.Self.Self.Self.Should().NotBeNull();
        p1.Self.Self.Self.Self.Self.Should().BeNull();
        
        p1.SelfList[0].Self.Self.Self.Should().NotBeNull();
        p1.SelfList[0].Self.Self.Self.Self.Should().BeNull();
        
        p1.SelfList[1].Self.Self.Self.Should().NotBeNull();
        p1.SelfList[1].Self.Self.Self.Self.Should().BeNull();
    }
    
    [Fact]
    public void Support_recursion_with_recursion_level_4()
    {
        var p1 = TestDataBuilder
            .For<ClassWithSelfRecursion>()
            .WithRecursionLevel(4)
            .Build();
        
        p1.Should().NotBeNull();
        p1.Self.Self.Self.Self.Should().NotBeNull();
        p1.Self.Self.Self.Self.Self.Should().BeNull();
    }
    
    [Fact]
    public void Support_recursion_with_recursion_level_1()
    {
        var p1 = TestDataBuilder
            .For<ClassWithSelfRecursion>()
            .WithRecursionLevel(1)
            .Build();
        
        p1.Should().NotBeNull();
        p1.Self.Should().NotBeNull();
        p1.Self.Self.Should().BeNull();
    }
    
    [Fact]
    public void Support_recursion_with_recursion_level_1_with_different_classes()
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
