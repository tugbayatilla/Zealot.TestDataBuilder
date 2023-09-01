using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithListSizeTests
{
    [Fact]
    public void Default_Queue_size_is_2()
    {
        var entity = TestDataBuilder
            .For<ClassWithQueue>()
            .Build();

        entity.Prop.Count.Should().Be(2);
    }
    
    [Fact]
    public void ArrayList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithArrayList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void Array_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoIntegerArray>()
            .WithListSize(3)
            .Build();

        entity.Prop1.Length.Should().Be(3);
    }
    
    [Fact]
    public void GenericList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void GenericIList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void IList_not_supported()
    {
        var entity = TestDataBuilder
            .For<ClassWithIList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void GenericICollection_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericICollection>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void ICollection_not_supported()
    {
        var entity = TestDataBuilder
            .For<ClassWithICollection>()
            .WithListSize(3)
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void LinkedList_not_supported()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericLinkedList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(0);
    }
    
    [Fact]
    public void GenericQueue_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericQueue>()
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
    public void Stack_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithStack>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }

    [Fact]
    public void GenericStack_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericStack>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void GenericIEnumerable_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIEnumerable>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count().Should().Be(3);
    }
    
    [Fact]
    public void IEnumerable_not_supported()
    {
        var entity = TestDataBuilder
            .For<ClassWithIEnumerable>()
            .WithListSize(3)
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void IReadOnlyList_size_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIReadOnlyList>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
    [Fact]
    public void IReadOnlyCollection_changed_to_3()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIReadOnlyCollection>()
            .WithListSize(3)
            .Build();

        entity.Prop.Count.Should().Be(3);
    }
    
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
    public void Accepts_only_positive_numbers()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneStringList>()
            .WithListSize(-1)
            .Build();

        entity.Prop.Count.Should().Be(0);
    }
}
