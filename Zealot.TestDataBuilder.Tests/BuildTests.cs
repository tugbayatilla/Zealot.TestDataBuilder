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
    
    [Fact]
    public void GIVEN_PublicWithOneInt_WHEN_Build_called_THEN_IntProp_is_1()
    {
        TestDataBuilder.For<PublicWithOneInt>().Build().IntProp.Should().Be(1);
    }
}