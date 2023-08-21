using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ListTests
{
    [Fact]
    public void Support_IListGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIList>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_IList()
    {
        var entity = TestDataBuilder
            .For<ClassWithIList>()
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void Support_ICollectionGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericICollection>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_ICollection()
    {
        var entity = TestDataBuilder
            .For<ClassWithICollection>()
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void Support_ArrayList()
    {
        var entity = TestDataBuilder
            .For<ClassWithArrayList>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_LinkedList()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericLinkedList>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_QueueGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericQueue>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Queue()
    {
        var entity = TestDataBuilder
            .For<ClassWithQueue>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Stack()
    {
        var entity = TestDataBuilder
            .For<ClassWithStack>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_StackGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericStack>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IEnumerableGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIEnumerable>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_IEnumerable()
    {
        var entity = TestDataBuilder
            .For<ClassWithIEnumerable>()
            .Build();

        entity.Prop.Should().BeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyCollectionGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIReadOnlyCollection>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyListGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIReadOnlyList>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
}
