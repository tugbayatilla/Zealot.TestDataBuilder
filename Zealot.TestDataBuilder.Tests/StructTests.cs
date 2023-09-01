using FluentAssertions.Equivalency;
using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct_as_property()
    {
        var subject = TestDataBuilder
            .For<ClassWithStructWithTwoString>()
            .Build();

        subject.Prop.Should().NotBeNull();
        subject.Prop.Prop.Should().MatchBuilderNamingRegex(nameof(subject.Prop.Prop));
        subject.Prop.PropNullable.Should().MatchBuilderNamingRegex(nameof(subject.Prop.PropNullable));
    }
    
    [Fact]
    public void Support_struct_directly()
    {
        var a = Convert.ToByte('A');
        var subject = TestDataBuilder
            .For<StructWithAllPrimitives>()
            .Build();

        subject.Should().NotBeNull();
        subject.BoolProp.Should().Be(true);
        subject.BoolNullableProp.Should().Be(true);
        subject.IntProp.Should().Be(1);
        subject.IntNullableProp.Should().Be(2);
        subject.FloatProp.Should().Be(3);
        subject.FloatNullableProp.Should().Be(4);
        subject.DoubleProp.Should().Be(5);
        subject.DoubleNullableProp.Should().Be(6);
        subject.DecimalProp.Should().Be(7);
        subject.DecimalNullableProp.Should().Be(8);
        subject.LongProp.Should().Be(9);
        subject.LongNullableProp.Should().Be(10);
        subject.ShortProp.Should().Be(11);
        subject.ShortNullableProp.Should().Be(12);
        subject.ByteProp.Should().Be(a);
        subject.ByteNullableProp.Should().Be(a);
        subject.CharProp.Equals('A').Should().BeTrue();
        subject.CharNullableProp!.Value.Equals('A').Should().BeTrue();
        subject.StringProp.Should().MatchBuilderNamingRegex(nameof(subject.StringProp));
        subject.StringNullableProp.Should().MatchBuilderNamingRegex(nameof(subject.StringNullableProp));
        subject.UInt16Prop.Should().Be(13);
        subject.UInt16NullableProp.Should().Be(14);
        subject.UInt32Prop.Should().Be(15);
        subject.UInt32NullableProp.Should().Be(16);
        subject.UInt64Prop.Should().Be(17);
        subject.UInt64NullableProp.Should().Be(18);
    }
    
    [Fact]
    public void Support_struct_recursion()
    {
        var subject = TestDataBuilder
            .For<StructWithIntAndItselfRecursively>()
            .WithRecursionLevel(1)
            .Build();

        subject.Should().NotBeNull();
        subject.Prop.IntProp.Should().Be(2);
    }
}
