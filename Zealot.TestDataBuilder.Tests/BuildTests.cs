namespace Zealot.SampleBuilder.Tests;

public class BuildTests
{
    [Fact]
    public void For_returns_builder_interface()
    {
        var forResult = TestDataBuilder.For<PublicEmpty>();

        forResult.Should().BeAssignableTo<IBuilder>();
    }
}