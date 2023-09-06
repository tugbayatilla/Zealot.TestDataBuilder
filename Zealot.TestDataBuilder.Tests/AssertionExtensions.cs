using FluentAssertions.Primitives;

namespace Zealot.Tests;

internal static class AssertionExtensions
{
    public static AndConstraint<StringAssertions> MatchBuilderNamingRegex(this StringAssertions stringAssertions) =>
         stringAssertions.Subject.Should().MatchRegex($"{TestDataBuilder.DefaultStringBodyTemplate}[0-9]");
}
