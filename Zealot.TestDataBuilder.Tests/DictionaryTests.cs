using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class DictionaryTests
{
    [Fact]
    public void Support_dictionary()
    {
        var entity = TestDataBuilder
            .For<ClassWithSomeDictionaries>()
            .Build();

        entity.ObjectAndObjectProp.Should().NotBeNull();
        entity.StringAndIntProp.Should().NotBeNull();
    }
    [Fact]
    public void Support_IReadOnlyDictionary()
    {
        var entity = TestDataBuilder
            .For<ClassWithSomeDictionaries>()
            .WithOnly(typeof(IReadOnlyDictionary<,>))
            .Build();

        entity.StringAndIntReadOnlyProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_dictionary_string_int_has_2_items()
    {
        var entity = TestDataBuilder
            .For<ClassWithDictionaryOfStringAndInt>()
            .Build();

        entity.Prop.Count.Should().Be(2);
    }
    
    [Fact]
    public void Support_dictionary_int_complex_has_2_items()
    {
        var entity = TestDataBuilder
            .For<ClassWithDictionaryOfIntAndClassWithAllPrimitives>()
            .Build();

        entity.Prop.Count.Should().Be(2);
        entity.Prop.Values.First().Should().NotBeNull();
    }
    
    [Fact]
    public void Support_dictionary_string_complex_has_2_items()
    {
        var entity = TestDataBuilder
            .For<ClassWithDictionaryOfStringAndClasWithAllPrimitives>()
            .Build();

        entity.Prop.Count.Should().Be(2);
        entity.Prop.Values.First().Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyDictionary_has_2_values()
    {
        var entity = TestDataBuilder
            .For<ClassWithSomeDictionaries>()
            .WithOnly(typeof(IReadOnlyDictionary<,>))
            .Build();

        entity.StringAndIntReadOnlyProp.Count.Should().Be(2);
    }
    
}
