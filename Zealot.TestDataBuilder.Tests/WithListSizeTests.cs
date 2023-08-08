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
}