using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithStringTests
{
    [Theory]
    [InlineData("", "", "{0}")]
    [InlineData("pre_", "", "pre_{0}")]
    [InlineData("", "_suf", "{0}_suf")]
    [InlineData("pre_", "_suf", "pre_{0}_suf")]
    public void Support_prefix_and_suffix(string prefix, string suffix, string result)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringPrefix(prefix)
            .WithStringSuffix(suffix)
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().MatchRegex(string.Format(result, nameof(instance.Prop1)));
    }
}
