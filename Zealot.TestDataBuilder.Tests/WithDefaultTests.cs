using System.Dynamic;
using System.Linq.Expressions;
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
    
    [Fact]
    public void Support_integers()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(default);
        instance.Prop2.Should().Be(default);
    }
}
