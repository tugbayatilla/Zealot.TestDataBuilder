using FluentAssertions.Primitives;

namespace Zealot.Tests;

internal static class AssertionExtensions
{
    public static AndConstraint<StringAssertions> MatchBuilderNamingRegex(this StringAssertions stringAssertions, string propertyName = "") =>
         stringAssertions.Subject.Should().MatchRegex($"{propertyName}");
}
