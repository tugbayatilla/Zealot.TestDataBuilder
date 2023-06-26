namespace Zealot.SampleBuilder.Tests;

public class BuildTests
{
    [Fact]
    public void For_returns_builder_interface()
    {
        var forResult = TestDataBuilder.For<PublicEmpty>();

        forResult.Should().BeAssignableTo<IBuilder<PublicEmpty>>();
    }
    
    [Fact]
    public void Build_returns_not_null_for_public_empty()
    {
        TestDataBuilder.For<PublicEmpty>().Build().Should().NotBeNull();
    }
}