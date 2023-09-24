using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class NumericTests
{
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
    public void Support_short()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoShort>()
            .Build();
        
        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_short_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoShortNullable>()
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
        
        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_double_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoDoubleNullable>()
            .Build();
        
        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }

    [Fact]
    public void Support_float_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoFloatNullable>()
            .Build();
        
        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
        subject.Prop1.Should().NotBe(subject.Prop2);
    }
    
    [Fact]
    public void Support_float()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoFloat>()
            .Build();
        
        subject.Prop1.Should().Be(1);
        subject.Prop2.Should().Be(2);
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
        
        subject.Prop1.Should().BeTrue();
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
