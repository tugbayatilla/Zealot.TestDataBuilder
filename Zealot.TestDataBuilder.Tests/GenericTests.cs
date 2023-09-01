namespace Zealot.Tests;

public class GenericTests
{
    [Fact]
    public void Support_generic_list_of_string()
    {
        var subject = TestDataBuilder
            .For<List<string>>()
            .Build();

        subject.Should().NotBeNull();
        subject.Count.Should().Be(2);
    }
    
    [Fact]
    public void Support_generic_dictionary_of_object_and_object()
    {
        var subject = TestDataBuilder
            .For<Dictionary<object,object>>()
            .Build();

        subject.Should().NotBeNull();
        subject.Count.Should().Be(2);
    }
}
