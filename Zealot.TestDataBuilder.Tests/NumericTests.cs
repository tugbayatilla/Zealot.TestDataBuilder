using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class NumericTests
{
    [Fact]
    public void Support_integer()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<int>()
            .Build();

        AssertIntProp(subject);
        
        TestHelper.CheckDefaultExcept<int>(subject);
    }

    internal static void AssertIntProp(PublicWithAll subject)
    {
        subject.IntProp.Should().NotBe(0);
        subject.IntProp2.Should().NotBe(0);

        subject.IntProp.Should().NotBe(subject.IntProp2);
    }

    [Fact]
    public void Support_double()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<double>()
            .Build();
        subject.DoubleProp.Should().NotBe(0);
        subject.DoubleProp2.Should().NotBe(0);

        subject.DoubleProp.Should().NotBe(subject.DoubleProp2);
    }
    
    [Fact]
    public void Support_short()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<short>()
            .Build();
        
        subject.ShortProp.Should().NotBe(0);
        subject.ShortProp2.Should().NotBe(0);

        subject.ShortProp.Should().NotBe(subject.ShortProp2);
    }
    
    [Fact]
    public void Support_integer_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<int?>()
            .Build();
        
        subject.IntNullableProp.Should().NotBe(0);
        subject.IntNullableProp2.Should().NotBe(0);

        subject.IntNullableProp.Should().NotBe(subject.IntNullableProp2);
    }
    
    [Fact]
    public void Support_short_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<short?>()
            .Build();
        
        subject.ShortNullableProp.Should().NotBeNull();
        subject.ShortNullableProp2.Should().NotBeNull();

        subject.ShortNullableProp.Should().NotBe(0);
        subject.ShortNullableProp2.Should().NotBe(0);

        subject.ShortNullableProp.Should().NotBe(subject.ShortNullableProp2);
    }
    
    [Fact]
    public void Support_double_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<double?>()
            .Build();
        
        subject.DoubleNullableProp.Should().NotBeNull();
        subject.DoubleNullableProp2.Should().NotBeNull();
        
        subject.DoubleNullableProp.Should().NotBe(0);
        subject.DoubleNullableProp2.Should().NotBe(0);

        subject.DoubleNullableProp.Should().NotBe(subject.DoubleNullableProp2);
    }

    [Fact]
    public void Support_float_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<float?>()
            .Build();
        
        subject.FloatNullableProp.Should().NotBeNull();
        subject.FloatNullableProp2.Should().NotBeNull();
        
        subject.FloatNullableProp.Should().NotBe(0);
        subject.FloatNullableProp2.Should().NotBe(0);

        subject.FloatNullableProp.Should().NotBe(subject.FloatNullableProp2);
    }
    
    [Fact]
    public void Support_float()
    {
        var subject = TestDataBuilder.For<PublicWithAll>()
                .SetOnly<float>()
                .Build();
        subject.FloatProp.Should().NotBe(0);
        subject.FloatProp2.Should().NotBe(0);

        subject.FloatProp.Should().NotBe(subject.FloatProp2);
    }
}
