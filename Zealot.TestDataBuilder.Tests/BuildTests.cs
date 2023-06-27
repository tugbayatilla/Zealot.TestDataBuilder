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
    public void Build_always_creates_an_instance()
    {
        TestDataBuilder.For<PublicEmpty>().Build().Should().NotBeNull();
    }

    [Fact]
    public void Throws_Exception_for_unsupported_types()
    {
        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            TestDataBuilder.For<PublicWithUnsupportedType>().Build();
        });
        exception.Message.Should().Be($"The strategy with type '{typeof(PublicWithUnsupportedType.UnsupportedType).FullName}' is not supported.");
    }
    
    [Fact]
    public void Support_all()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .Build();
        
        NumericTests.AssertIntProp(subject);
        // todo: get the rest here
    }
}