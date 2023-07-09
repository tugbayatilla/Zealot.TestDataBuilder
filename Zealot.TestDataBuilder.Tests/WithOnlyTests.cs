using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithOnlyTests
{
    [Fact]
    public void WithOnly_string()
    {
        var entity = TestDataBuilder
            .For<AllPrimitivesClass>()
            .WithOnly<string>()
            .Build();

        TestHelper.CheckDefaultExcept<string>(entity);
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
