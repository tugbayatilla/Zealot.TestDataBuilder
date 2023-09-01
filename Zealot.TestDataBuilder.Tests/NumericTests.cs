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
            .For<ClassWithAllPrimitives>()
            .WithOnly<int>()
            .Build();

        subject.IntProp.Should().NotBe(0);
        subject.IntProp2.Should().NotBe(0);

        subject.IntProp.Should().NotBe(subject.IntProp2);

        TestHelper.CheckDefaultExcept<int>(subject);
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
    public void Support_integer_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<int?>()
            .Build();
        
        subject.IntNullableProp.Should().NotBe(0);
        subject.IntNullableProp2.Should().NotBe(0);

        subject.IntNullableProp.Should().NotBe(subject.IntNullableProp2);
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
            .For<ClassWithAllPrimitives>()
            .WithOnly<float?>()
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
        var subject = TestDataBuilder.For<ClassWithAllPrimitives>()
                .WithOnly<float>()
                .Build();
        subject.FloatProp.Should().NotBe(0);
        subject.FloatProp2.Should().NotBe(0);

        subject.FloatProp.Should().NotBe(subject.FloatProp2);
    }
    
    [Fact]
    public void Support_unsigned_int16()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<ushort>()
            .Build();
        subject.UInt16Prop.Should().NotBe(0);
        subject.UInt16Prop2.Should().NotBe(0);

        subject.UInt16Prop.Should().NotBe(subject.UInt16Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int16_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<ushort?>()
            .Build();
        subject.UInt16NullableProp.Should().NotBe(0);
        subject.UInt16NullableProp2.Should().NotBe(0);

        subject.UInt16NullableProp.Should().NotBe(subject.UInt16NullableProp2);
    }
    
    [Fact]
    public void Support_unsigned_int32()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<uint>()
            .Build();
        subject.UInt32Prop.Should().NotBe(0);
        subject.UInt32Prop2.Should().NotBe(0);

        subject.UInt32Prop.Should().NotBe(subject.UInt32Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int32_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<uint?>()
            .Build();
        subject.UInt32NullableProp.Should().NotBe(0);
        subject.UInt32NullableProp2.Should().NotBe(0);

        subject.UInt32NullableProp.Should().NotBe(subject.UInt32NullableProp2);
    }
    
    [Fact]
    public void Support_unsigned_int64()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<ulong>()
            .Build();
        subject.UInt64Prop.Should().NotBe(0);
        subject.UInt64Prop2.Should().NotBe(0);

        subject.UInt64Prop.Should().NotBe(subject.UInt64Prop2);
    }
    
    [Fact]
    public void Support_unsigned_int64_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<ulong?>()
            .Build();
        subject.UInt64NullableProp.Should().NotBe(0);
        subject.UInt64NullableProp2.Should().NotBe(0);

        subject.UInt64NullableProp.Should().NotBe(subject.UInt64NullableProp2);
    }
    
}
