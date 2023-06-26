using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class NumericTests
{
    [Fact]
    public void GIVEN_PublicWithOneInt_WHEN_Build_called_THEN_IntProp_is_1()
    {
        TestDataBuilder.For<PublicWithOneInt>().Build().IntProp.Should().Be(1);
    }
    
    [Fact]
    public void GIVEN_PublicWithOneFloat_WHEN_Build_called_THEN_FloatProp_is_1()
    {
        TestDataBuilder.For<PublicWithOneFloat>().Build().FloatProp.Should().Be(1);
    }
    
    [Fact]
    public void GIVEN_PublicWithTwoInt_WHEN_Build_called_THEN_property_values_must_be_different()
    {
        var subject = TestDataBuilder.For<PublicWithTwoInt>().Build();
        subject.IntProp.Should().NotBe(0);
        subject.IntProp2.Should().NotBe(0);

        subject.IntProp.Should().NotBe(subject.IntProp2);
    }
    
    [Fact]
    public void GIVEN_PublicWithTwoDouble_WHEN_Build_called_THEN_property_values_must_be_different()
    {
        var subject = TestDataBuilder.For<PublicWithTwoDouble>().Build();
        subject.DoubleProp.Should().NotBe(0);
        subject.DoubleProp.Should().NotBe(0);

        subject.DoubleProp.Should().NotBe(subject.DoubleProp2);
    }
}
