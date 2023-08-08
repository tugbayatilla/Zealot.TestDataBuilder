using System.Collections;
using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithListSizeTests
{
    [Fact]
    public void Default_List_size_is_2()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneStringList>()
            .Build();

        entity.Prop.Count.Should().Be(2);
    }
    
    [Fact]
    public void Change_size_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneStringList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void Queue_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithQueue>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void Default_Queue_size_is_2()
    {
        var entity = TestDataBuilder
            .For<ClassWithQueue>()
            .Build();

        entity.Prop.Count.Should().Be(2);
    }
    
    [Fact]
    public void Array_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoIntegerArray>()
            .WithListSize(3)
            .Build();

        entity.Prop1.Count().Should().Be(3);
    }
    
    [Fact]
    public void Stack_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .WithListSize(3)
            .Build();

        entity.StackProp.Count.Should().Be(3);
    }
    
    [Fact]
    public void ArrayList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .WithListSize(3)
            .Build();

        entity.ArrayListProp.Count.Should().Be(3);
    }
    
    [Fact]
    public void IReadOnlyList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .WithListSize(3)
            .Build();

        entity.IReadOnlyListStringProp.Count.Should().Be(3);
    }
}