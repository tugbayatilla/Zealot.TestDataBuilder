using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithDefaultTests
{
    [Fact]
    public void Support_string()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(default);
        instance.Prop2.Should().Be(default);
    }
}
