using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ListTests
{
    [Fact]
    public void Support_IListOfString()
    {
        var entity = TestDataBuilder
            .For<ClassWithIListOfString>()
            .Build();

        entity.Prop.Should().NotBeNull();
        entity.Prop.Count.Should().Be(2);
        entity.Prop[0].Should().Be("test_1");
        entity.Prop[1].Should().Be("test_2");
    }
    
    [Fact]
    public void Support_IListOfClassWithTwoString()
    {
        var entity = TestDataBuilder
            .For<ClassWithIListOfClassWithTwoString>()
            .Build();

        entity.Prop.Should().NotBeNull();
        entity.Prop.Count.Should().Be(2);
        entity.Prop[0].Prop1.Should().Be("test_1");
        entity.Prop[0].Prop2.Should().Be("test_2");
        entity.Prop[1].Prop1.Should().Be("test_3");
        entity.Prop[1].Prop2.Should().Be("test_4");
    }
    
    [Fact]
    public void Support_IListGeneric()
    {
        var entity = TestDataBuilder
            .For<ClassWithGenericIList>()
            .Build();

        entity.Prop.Should().NotBeNull();
        entity.Prop.Count.Should().Be(2);
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
