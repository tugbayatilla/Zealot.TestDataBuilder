using Zealot.Internals;
using Zealot.Internals.Interfaces;
using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithOnlyTests
{
    [Fact]
    public void WithOnly_string()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntegerAndString>()
            .WithOnly<string>()
            .Build();

        entity.StringProp.Should().MatchBuilderNamingRegex();
        entity.IntProp.Should().Be(0);
    }
    
    [Fact]
    public void WithOnly_int()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntegerAndString>()
            .WithOnly<int>()
            .Build();

        entity.StringProp.Should().BeNullOrWhiteSpace();
        entity.IntProp.Should().Be(1);
    }
    
    [Fact]
    public void WithOnly_has_idempotency()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntegerAndString>()
            .WithOnly<string>()
            .WithOnly<string>()
            .Build();

        entity.StringProp.Should().MatchBuilderNamingRegex();
        entity.IntProp.Should().Be(0);
    }

    [Fact]
    public void IWithOnlyContainer_Exist_with_IReadOnlyDictionary()
    {
        IWithOnly container = new WithOnly();
        container.Add(typeof(IReadOnlyDictionary<,>));

        container
            .Exist(typeof(IReadOnlyDictionary<string, int>))
            .Should()
            .BeTrue();
    }
    
    [Fact]
    public void IWithOnlyContainer_Exist_with_NullableDouble()
    {
        IWithOnly container = new WithOnly();
        container.Add(typeof(double?));

        container
            .Exist(typeof(int?))
            .Should()
            .BeFalse();
    }
}
