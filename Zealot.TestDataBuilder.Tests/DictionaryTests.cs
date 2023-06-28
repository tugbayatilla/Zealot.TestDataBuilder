using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class DictionaryTests
{
    [Fact]
    public void Support_dictionary()
    {
        var entity = TestDataBuilder
            .For<InternalWithDictionary>()
            .Build();

        entity.DictionaryProp.Should().NotBeNull();
        entity.DictionaryStringIntProp.Should().NotBeNull();
    }
}