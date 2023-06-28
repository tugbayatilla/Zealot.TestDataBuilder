using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ListTests
{
    [Fact]
    public void Support_IList()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.IListStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_ICollectionGeneric()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.ICollectionStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void NotSupport_ICollection()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.ICollectionProp.Should().BeNull();
    }
    
    [Fact]
    public void Support_ArrayList()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.ArrayListProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_LinkedList()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.LinkedListStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_QueueGeneric()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.QueueStringProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Queue()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.QueueProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_Stack()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.StackProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_StackGeneric()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.StackStringProp.Should().NotBeNull();
    }
}