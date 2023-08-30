using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ConstructorHavingParameterTests
{
    [Fact]
    public void Should_be_not_null()
    {
        var entity = TestDataBuilder
            .For<ClassWithConstructorHavingParameter>()
            .Build();

        entity.Should().NotBeNull();
    }

    [Fact]
    public void Prop1_should_be_assigned()
    {
        var entity = TestDataBuilder
            .For<ClassWithConstructorHavingParameter>()
            .Build();

        entity.Prop1.Should().MatchRegex("Prop1_[0-9]");
    }
}