using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ParameterlessConstructorSupportTests
{
    [Fact]
    public void Should_be_not_null()
    {
        var entity = TestDataBuilder
            .For<ClassWithoutParameterlessConstructor>()
            .Build();

        entity.Should().NotBeNull();
    }

    [Fact]
    public void Prop1_should_be_assigned()
    {
        var entity = TestDataBuilder
            .For<ClassWithoutParameterlessConstructor>()
            .Build();

        entity.Prop1.Should().MatchRegex("Prop1_[0-9]");
    }
}
