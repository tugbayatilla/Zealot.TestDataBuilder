using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ListTests
{
    [Fact]
    public void Support_IListGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IListStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_IList()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IListProp.Should().BeNull();
    }
    
    [Fact]
    public void Support_ICollectionGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.ICollectionStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_ICollection()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.ICollectionProp.Should().BeNull();
    }
    
    [Fact]
    public void Support_ArrayList()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.ArrayListProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_LinkedList()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.LinkedListStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_QueueGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.QueueStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Queue()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.QueueProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Stack()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.StackProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_StackGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.StackStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IEnumerableGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IEnumerableStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_IEnumerable()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IEnumerableProp.Should().BeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyCollectionGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IReadOnlyCollectionStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyListGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllList>()
            .Build();

        entity.IReadOnlyListStringProp.Should().NotBeNull();
    }
}