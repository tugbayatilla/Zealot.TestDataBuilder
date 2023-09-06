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
        instance.Prop1.Should().Be($"{body}_1");
        instance.Prop2.Should().Be($"{body}_2");
    }
}
