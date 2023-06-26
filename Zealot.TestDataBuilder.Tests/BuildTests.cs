using Zealot.SampleBuilder.Tests.TestObjects;

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
    public void UnsupportedException()
    {
        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            TestDataBuilder.For<PublicWithUnsupportedType>().Build();
        });
        exception.Message.Should().Be($"The strategy with type '{typeof(PublicWithUnsupportedType.UnsupportedType).FullName}' is not supported.");
    }
}