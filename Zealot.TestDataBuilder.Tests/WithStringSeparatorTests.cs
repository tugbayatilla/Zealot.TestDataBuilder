using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithStringSeparatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData("#")]
    public void Support_changing_string_separator(string separator)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringSeparator(separator)
            .Build();
        
        instance.Should().NotBeNull();
        instance.Prop1.Should().Be($"{nameof(instance.Prop1)}{separator}1");
        instance.Prop2.Should().Be($"{nameof(instance.Prop2)}{separator}2");
    }
}
