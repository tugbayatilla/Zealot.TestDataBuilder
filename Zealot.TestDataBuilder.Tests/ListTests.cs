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
    public void Support_ICollection()
    {
        var entity = TestDataBuilder
            .For<InternalWithIListString>()
            .Build();

        entity.ICollectionStringProp.Should().NotBeNull();
    }
}