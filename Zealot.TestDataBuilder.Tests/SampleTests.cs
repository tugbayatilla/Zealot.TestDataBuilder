using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class SampleTests
{
    [Fact]
    public void Should_create_same_instance_when_build_method_called()
    {
        var now = DateTime.Now;

        var p1 = TestDataBuilder.For<ClassWithEquality>().WithDate(now).Build();
        var p2 = TestDataBuilder.For<ClassWithEquality>().WithDate(now).Build();

        p1.Should().Be(p2);
    }

    [Fact]
    public void Should_create_new_instance_every_time_when_build_method_called()
    {
        var builder = TestDataBuilder.For<ClassWithEquality>();
        var p1 = builder.Build();
        var p2 = builder.Build();

        p1.Should().NotBe(p2);
    }

    [Fact]
    public void Should_create_and_fill_when_having_iList_interface_property()
    {
        var now = DateTime.Now;
        var instance = TestDataBuilder
            .For<ClassHavingIListInterfaceAsProperty>()
            .WithDate(now)
            .Build();

        instance.Should().NotBeNull();
        instance.IListInterfaceProperty.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Should_create_private_constructor_property_be_null()
    {
        var instance = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        instance.Should().NotBeNull();
        instance.ClassWithPrivateConstructorProp.Should().BeNull();
    }

    
    [Fact]
    public void Should_fill_primitive_values()
    {
        var now = DateTime.Now;
        var guid = Guid.NewGuid();
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .WithDate(now)
            .WithGuid(guid)
            .Build();

        sample.Should().NotBeNull();
        sample.BooleanProperty.Should().BeTrue();
        sample.BooleanPropertyNullable.Should().BeTrue();

        sample.ByteProperty.Should().NotBe(default);
        sample.BytePropertyNullable.Should().NotBe(default);

        sample.DateTimeProperty.Should().NotBe(default);
        sample.DateTimePropertyNullable.Should().NotBe(default);

        sample.DecimalProperty.Should().NotBe(default);
        sample.DecimalPropertyNullable.Should().NotBe(default);

        sample.DoubleProperty.Should().NotBe(default);
        sample.DoublePropertyNullable.Should().NotBe(default);

        sample.FloatProperty.Should().NotBe(default);
        sample.FloatPropertyNullable.Should().NotBe(default);

        sample.Int16Property.Should().NotBe(default);
        sample.Int16PropertyNullable.Should().NotBe(default);

        sample.Int64Property.Should().NotBe(default);
        sample.Int64PropertyNullable.Should().NotBe(default);

        sample.IntProperty.Should().NotBe(default);
        sample.IntPropertyNullable.Should().NotBe(default);

        sample.SingleProperty.Should().NotBe(default);
        sample.SinglePropertyNullable.Should().NotBe(default);

        sample.StringProperty.Should().MatchBuilderNamingRegex(nameof(sample.StringProperty));
        sample.StringPropertyNullable.Should().MatchBuilderNamingRegex(nameof(sample.StringPropertyNullable));

        sample.UInt16Property.Should().NotBe(default);
        sample.UInt16PropertyNullable.Should().NotBe(default);

        sample.UInt64Property.Should().NotBe(default);
        sample.UInt64PropertyNullable.Should().NotBe(default);

        sample.UIntProperty.Should().NotBe(default);
        sample.UIntPropertyNullable.Should().NotBe(default);

        sample.GuidProperty.Should().Be(guid);
        sample.GuidPropertyNullable.Should().Be(guid);
    }


    [Fact]
    public void Should_fill_simple_sub_class_property()
    {
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        sample.ClassWithOnePropertyWithoutSetter.Should().NotBeNull();
        sample.ClassWithOnePropertyWithoutSetter.IntProperty.Should().NotBe(default);
        sample.ClassWithOnePropertyWithoutSetter.StringProperty.Should()
            .MatchBuilderNamingRegex(nameof(sample.ClassWithOnePropertyWithoutSetter.StringProperty));
    }

    [Fact]
    public void Should_fill_inherited_sub_class_property()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .WithDate(now)
            .Build();

        sample.ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger.Should().NotBeNull();
        sample.ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger.DateTimeProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_list_property()
    {
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        sample.SampleDataSimpleSubClassList.Should().NotBeNull();
        sample.SampleDataSimpleSubClassList.Count.Should().Be(2);

        sample.SampleDataSimpleSubClassList[0].IntProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_list_interface_property()
    {
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        sample.SampleDataSimpleSubClassIListInterface.Should().NotBeNullOrEmpty();
        sample.SampleDataSimpleSubClassIListInterface[0].IntProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_collection_interface_property()
    {
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        sample.SampleDataSimpleSubClassICollectionInterface.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Should_fill_generic_enumeration_interface_property()
    {
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .Build();

        sample.SampleDataSimpleSubClassIEnumerableInterface.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Should_create_sample_data_for_having_another_class_as_property()
    {
        var instance = TestDataBuilder
            .For<ClassHavingAnotherClassAsProperty>()
            .Build();

        instance.ClassWithInheritanceProp.Should().NotBeNull();
        instance.ClassWithInheritanceProp.PropBase.Should()
            .MatchBuilderNamingRegex(nameof(instance.ClassWithInheritanceProp.PropBase));
        instance.ClassWithInheritanceProp.PropListBase.Count.Should().Be(2);
        instance.ClassWithInheritanceProp.PropListBase[0].Should()
            .MatchBuilderNamingRegex(nameof(instance.ClassWithInheritanceProp.PropListBase));
        instance.ClassWithInheritanceProp.PropListBase[1].Should()
            .MatchBuilderNamingRegex(nameof(instance.ClassWithInheritanceProp.PropListBase));
    }
    
    [Fact]
    public void Should_be_nullable_enum_class_be_filled()
    {
        var p1 = TestDataBuilder
            .For<ClassWithOneEnumWithOneItemNullable>()
            .Build();

        p1.Should().NotBeNull();
        p1.Prop.Should().Be(EnumWithOneItem.Item1);
    }

    [Fact]
    public void Support_class_with_one_enum_with_nothing()
    {
        var p1 = TestDataBuilder
            .For<ClassWithOneEnumWithNothing>()
            .Build();

        p1.Should().NotBeNull();
        p1.Prop.Should().Be(0);
    }

    [Fact]
    public void Should_create_sample_for_SampleArrayPropertyClass()
    {
        var p1 = TestDataBuilder
            .For<ClassWithOneClassOfGodAndAClassOfRecursive>()
            .Build();

        p1.Should().NotBeNull();

        p1.ClassOfGodArrayProp.Should().NotBeNull();
        p1.ClassOfGodArrayProp.Length.Should().Be(2);
        p1.ClassOfGodArrayProp[0].BooleanProperty.Should().BeTrue();

        // A
        p1.RecursiveA.Should().NotBeNull();
        p1.RecursiveA.Name.Should().MatchBuilderNamingRegex(nameof(p1.RecursiveA.Name));

        // Ref B
        p1.RecursiveA.RefB.Should().NotBeNull();
        p1.RecursiveA.RefB.Name.Should().MatchBuilderNamingRegex(nameof(p1.RecursiveA.RefB.Name));
        
        // Ref B under Ref C
        p1.RecursiveA.RefB.RefC.Should().NotBeNull();
        p1.RecursiveA.RefB.RefC.Name.Should().MatchBuilderNamingRegex(nameof(p1.RecursiveA.RefB.RefC.Name));

        // Ref A - No recursion so it should be null
        p1.RecursiveA.RefB.RefC.RefA.Should().BeNull();

        // Ref A list
        p1.RecursiveA.RefB.RefC.RefAList.Should().NotBeNull();
        p1.RecursiveA.RefB.RefC.RefAList.Count.Should().Be(2);
        
        //No recursion so elements inside list should be null
        p1.RecursiveA.RefB.RefC.RefAList[0].Should().BeNull();
        p1.RecursiveA.RefB.RefC.RefAList[1].Should().BeNull();
    }
}
