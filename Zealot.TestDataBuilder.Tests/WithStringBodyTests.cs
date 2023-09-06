using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithStringBodyTests
{
    [Theory]
    [InlineData("")]
    [InlineData("test")]
    public void Support_changing_string_body(string body)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringBody(body)
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be($"{body}");
        instance.Prop2.Should().Be($"{body}");
    }

    [Fact]
    public void Default_is_property_name()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().MatchBuilderNamingRegex(nameof(instance.Prop1));
        instance.Prop2.Should().MatchBuilderNamingRegex(nameof(instance.Prop2));
    }
}
