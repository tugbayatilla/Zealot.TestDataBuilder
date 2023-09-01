using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class NumericTests
{
    [Theory]
    [InlineData(typeof(string))]
    [InlineData(typeof(int))]
    [InlineData(typeof(int?))]
    [InlineData(typeof(double))]
    [InlineData(typeof(double?))]
    [InlineData(typeof(float))]
    [InlineData(typeof(float?))]
    [InlineData(typeof(long))]
    [InlineData(typeof(long?))]
    [InlineData(typeof(short))]
    [InlineData(typeof(short?))]
    public void Support_type(Type setOnlyType)
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly(setOnlyType)
            .Build();

        TestHelper.AssertAllPropertiesWithSetOnly(subject, setOnlyType);
    }
    
    [Fact]
    public void Support_integer()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .Build();

        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_integer_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoIntegerNullable>()
            .Build();

        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }

    [Fact]
    public void Support_double()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoDouble>()
            .Build();
        subject.DoubleProp.Should().NotBe(0);
        subject.DoubleProp2.Should().NotBe(0);

        subject.DoubleProp.Should().NotBe(subject.DoubleProp2);
    }
    
    [Fact]
    public void Support_short()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<short>()
            .Build();
        
        subject.ShortProp.Should().NotBe(0);
        subject.ShortProp2.Should().NotBe(0);

        subject.ShortProp.Should().NotBe(subject.ShortProp2);
    }
    
    [Fact]
    public void Support_short_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<short?>()
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
            .For<ClassWithTwoDoubleNullable>()
            .WithOnly<double?>()
            .Build();
        
        subject.Prop1.Should().NotBeNull();
        subject.Prop2.Should().NotBeNull();
        
        subject.Prop1.Should().NotBe(0);
        subject.Prop2.Should().NotBe(0);

        subject.Prop1.Should().NotBe(subject.Prop2);
    }

    [Fact]
    public void Support_float_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoFloatNullable>()
            .Build();
        
        subject.Prop1.Should().Be(0);
        subject.Prop2.Should().Be(1);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_float()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoFloat>()
            .Build();
        
        subject.Prop1.Should().Be(0);
        subject.Prop2.Should().Be(1);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int16()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt16>()
            .Build();
        
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int16_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt16Nullable>()
            .Build();
        
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int32()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt32>()
            .Build();
        
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int32_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt32Nullable>()
            .Build();
        
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int64()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt64>()
            .WithOnly<ulong>()
            .Build();
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);

        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int64_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoUnsignedInt64Nullable>()
            .Build();
        
        subject.Prop.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_bool()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoBool>()
            .Build();
        
        subject.Prop.Should().BeTrue();
        subject.Prop2.Should().BeTrue();
    }
    
    [Fact]
    public void Support_bool_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoBoolNullable>()
            .Build();
        
        subject.Prop1.Should().BeTrue();
        subject.Prop2.Should().BeTrue();
    }
}
