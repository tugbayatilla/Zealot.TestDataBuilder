using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class SampleTests
{
    [Fact]
    public void Should_dictionary_initialized()
    {
        var entity = TestDataBuilder
            .For<SampleDataWithDictionary>()
            .Build();

        entity.DictionaryProperty.Should().NotBeNull();
    }
    
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
    public void Should_create_and_fill_when_having_ilist_interface_property()
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
    public void Should_create_and_fill_company()
    {
        var now = DateTime.Now;
        var instance = TestDataBuilder
            .For<Company>()
            .WithDate(now)
            .Build();

        instance.Should().NotBeNull();

        instance.CompanyId.Should().NotBe(default);
        instance.Branches.Should().NotBeNull();

        instance.MainAddress.Should().NotBeNull();
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
        sample.BooleanProperty.Should().BeFalse();
        sample.BooleanPropertyNullable.Should().BeFalse();

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

        sample.StringProperty.Should().Be("StringProperty");
        sample.StringPropertyNullable.Should().Be("StringPropertyNullable");

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
        sample.ClassWithOnePropertyWithoutSetter.StringProperty.Should().Be("StringProperty");
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
    public void Should_fill_primitive_constructor_sub_class_property()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<ClassOfGod>()
            .WithDate(now)
            .Build();

        sample.SampleDataPrimitiveConstructorSubClass.Should().NotBeNull();
        sample.SampleDataPrimitiveConstructorSubClass.DateTimeProperty.Should().NotBe(default);
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
    public void Should_create_sample_data_for_inherited_class()
    {
        var instance = TestDataBuilder
            .For<InheritedClass>()
            .Build();

        instance.BaseStringProp.Should().Be(nameof(instance.BaseStringProp));
        instance.StringProp1.Should().Be(nameof(instance.StringProp1));
        instance.ListOfStringProp.Count.Should().Be(2);
        instance.ListOfStringProp[0].Should().Be("1");//AdditionalLines_1
        instance.ListOfStringProp[1].Should().Be("2");//AdditionalLines_2
    }

    [Fact]
    public void Should_create_sample_data_for_having_another_class_as_property()
    {
        var instance = TestDataBuilder
            .For<ClassHavingAnotherClassAsProperty>()
            .Build();

        instance.InheritedClassProp.Should().NotBeNull();
        instance.InheritedClassProp.StringProp1.Should().Be(nameof(instance.InheritedClassProp.StringProp1));
        instance.InheritedClassProp.ListOfStringProp.Count.Should().Be(2);
        instance.InheritedClassProp.ListOfStringProp[0].Should().Be("1");//AdditionalLines_0
        instance.InheritedClassProp.ListOfStringProp[1].Should().Be("2");//AdditionalLines_1
    }

    [Theory]
    [InlineData("", "", "{0}")]
    [InlineData("pre_", "", "pre_{0}")]
    [InlineData("", "_suf", "{0}_suf")]
    [InlineData("pre_", "_suf", "pre_{0}_suf")]
    public void support_prefix_ans_suffix(string prefix, string suffix, string result)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringPrefix(prefix)
            .WithStringSuffix(suffix)
            .Build();

        instance.Should().NotBeNull();
        instance.Prop1.Should().Be(string.Format(result, nameof(instance.Prop1)));
    }

    [Fact]
    public void Should_be_recursive_list_property_must_be_filled()
    {
        var p1 = TestDataBuilder
            .For<ClassWithThreeClassRecursively.A>()
            .WithRecursionLevel(4)
            .Build();
        
        p1.Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list.Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list.Count.Should().Be(2);
        p1.Ref_B.Ref_C.Ref_A_list[0].Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list[0].Ref_B.Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list[0].Ref_B.Ref_C.Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list[0].Ref_B.Ref_C.Ref_A_list.Should().NotBeNull();
        p1.Ref_B.Ref_C.Ref_A_list[0].Ref_B.Ref_C.Ref_A_list[0].Should().NotBeNull();
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
        p1.ClassOfGodArrayProp[0].BooleanProperty.Should().BeFalse();

        p1.Recursive_A.Should().NotBeNull();
    }
}