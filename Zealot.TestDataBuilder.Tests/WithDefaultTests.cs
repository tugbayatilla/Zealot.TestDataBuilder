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
    
    [Fact]
    public void Support_Guid()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoGuid>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(Guid.Empty);
        instance.Prop2.Should().Be(Guid.Empty);
    }
    
    [Fact]
    public void Support_Char()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoChar>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(default);
        instance.Prop2.Should().Be(default);
    }
    
    [Fact]
    public void Support_Byte()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoByte>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(default);
        instance.Prop2.Should().Be(default);
    }
    
    [Fact]
    public void Support_Boolean()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoBool>()
            .WithDefault()
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(default);
        instance.Prop2.Should().Be(default);
    }
}
