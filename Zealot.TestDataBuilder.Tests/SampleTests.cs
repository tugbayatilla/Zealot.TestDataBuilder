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

        var p1 = TestDataBuilder.For<SampleDataClassForEquality>().WithDate(now).Build();
        var p2 = TestDataBuilder.For<SampleDataClassForEquality>().WithDate(now).Build();

        p1.Should().Be(p2);
    }

    [Fact]
    public void Should_create_new_instance_every_time_when_build_method_called()
    {
        var builder = TestDataBuilder.For<SampleDataClassForEquality>();
        var p1 = builder.Build();
        var p2 = builder.Build();

        p1.Should().NotBe(p2);
    }

    [Fact]
    public void Should_run_extension_method()
    {
        var p2 = TestDataBuilder
            .For<ClassHavingEnumProperty>()
            .WithValue(p => p.SampleEnumProperty = ClassHavingEnumProperty.SampleEnum.Value2)
            .Build();

        p2.SampleEnumProperty.Should().Be(ClassHavingEnumProperty.SampleEnum.Value2);
    }


    [Fact]
    public void Should_fill_class_having_enum_property()
    {
        var sample = TestDataBuilder
            .For<ClassHavingEnumProperty>()
            .WithValue(p => p.SampleEnumProperty = ClassHavingEnumProperty.SampleEnum.Value2)
            .Build();

        sample.SampleEnumProperty.Should().Be(ClassHavingEnumProperty.SampleEnum.Value2);
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
            .For<SampleDataClass>()
            .Build();

        instance.Should().NotBeNull();
        instance.SampleDataPrivateConstructorSubClass.Should().BeNull();
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
            .For<SampleDataClass>()
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
            .For<SampleDataClass>()
            .Build();

        sample.SampleDataSimpleSubClass.Should().NotBeNull();
        sample.SampleDataSimpleSubClass.IntProperty.Should().NotBe(default);
        sample.SampleDataSimpleSubClass.StringProperty.Should().Be("StringProperty");
    }

    [Fact]
    public void Should_fill_inherited_sub_class_property()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .WithDate(now)
            .Build();

        sample.SampleDataInheritedSubClass.Should().NotBeNull();
        sample.SampleDataInheritedSubClass.DateTimeProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_primitive_constructor_sub_class_property()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .WithDate(now)
            .Build();

        sample.SampleDataPrimitiveConstructorSubClass.Should().NotBeNull();
        sample.SampleDataPrimitiveConstructorSubClass.DateTimeProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_list_property()
    {
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .Build();

        sample.SampleDataSimpleSubClassList.Should().NotBeNull();
        sample.SampleDataSimpleSubClassList.Count.Should().Be(2);

        sample.SampleDataSimpleSubClassList[0].IntProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_list_interface_property()
    {
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .Build();

        sample.SampleDataSimpleSubClassIListInterface.Should().NotBeNullOrEmpty();
        sample.SampleDataSimpleSubClassIListInterface[0].IntProperty.Should().NotBe(default);
    }

    [Fact]
    public void Should_fill_generic_collection_interface_property()
    {
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .Build();

        sample.SampleDataSimpleSubClassICollectionInterface.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Should_fill_generic_enumeration_interface_property()
    {
        var sample = TestDataBuilder
            .For<SampleDataClass>()
            .Build();

        sample.SampleDataSimpleSubClassIEnumerableInterface.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Should_create_sample_data_for_inherited_class()
    {
        var instance = TestDataBuilder
            .For<InheritedClass>()
            .Build();

        instance.Addressing.Should().Be(nameof(instance.Addressing));
        instance.City.Should().Be(nameof(instance.City));
        instance.CountryIsoAlpha2Code.Should().Be(nameof(instance.CountryIsoAlpha2Code));
        instance.AdditionalLines.Count.Should().Be(2);
        instance.AdditionalLines[0].Should().Be("1");//AdditionalLines_1
        instance.AdditionalLines[1].Should().Be("2");//AdditionalLines_2
    }

    [Fact]
    public void Should_create_sample_data_for_having_another_class_as_property()
    {
        var instance = TestDataBuilder
            .For<ClassHavingAnotherClassAsProperty>()
            .Build();

        instance.Address.Should().NotBeNull();
        instance.Address.Name.Should().Be(nameof(instance.Address.Name));
        instance.Address.AdditionalLines.Count.Should().Be(2);
        instance.Address.AdditionalLines[0].Should().Be("1");//AdditionalLines_0
        instance.Address.AdditionalLines[1].Should().Be("2");//AdditionalLines_1
    }

    [Theory]
    [InlineData("", "", "{0}")]
    [InlineData("pre_", "", "pre_{0}")]
    [InlineData("", "_suf", "{0}_suf")]
    [InlineData("pre_", "_suf", "pre_{0}_suf")]
    public void support_prefix_ans_suffix(string prefix, string suffix, string result)
    {
        var instance = TestDataBuilder
            .For<StringPropertyClass>()
            .WithStringPrefix(prefix)
            .WithStringSuffix(suffix)
            .Build();

        instance.Should().NotBeNull();
        instance.StringProp.Should().Be(string.Format(result, nameof(instance.StringProp)));
    }

    [Fact]
    public void Should_be_recursive_list_property_must_be_filled()
    {
        var p1 = TestDataBuilder
            .For<SampleRecursiveListClass.A>()
            .WithRecursionLevel(4)
            .Build();

        //Assert
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
            .For<SampleNullableEnumClass>()
            .Build();

        p1.Should().NotBeNull();
        p1.SampleNullableEnum.Should().Be(SampleNullableEnum.OnlyItem);
    }

    [Fact]
    public void Should_be_nullable_enum_class_be_filled_and_enum_index_1_picked()
    {
        //todo: select index on enums, if no support then remove this test 
        var p1 = TestDataBuilder
            .For<SampleNullableEnumClass>()
            .WithValue(@class => @class.SampleNullableEnum = SampleNullableEnum.OnlyItem2)
            .Build();

        p1.Should().NotBeNull();
        p1.SampleNullableEnum.Should().Be(SampleNullableEnum.OnlyItem2);
    }

    [Fact]
    public void Should_create_sample_for_SampleEnumNoElementClass()
    {
        var p1 = TestDataBuilder
            .For<SampleEnumNoElementClass>()
            .Build();

        //Assert
        p1.Should().NotBeNull();
        p1.SampleEnumNoElementEnumProperty.Should().Be(0);
    }
    
    [Fact]
    public void Should_create_sample_for_SampleArrayPropertyClass()
    {
        var p1 = TestDataBuilder
            .For<SampleArrayPropertyClass>()
            .Build();

        //Assert
        p1.Should().NotBeNull();
        
        p1.SampleDataClassArray.Should().NotBeNull();
        p1.SampleDataClassArray.Length.Should().Be(2);
        p1.SampleDataClassArray[0].BooleanProperty.Should().BeFalse();

        p1.Recursive_A.Should().NotBeNull();
    }
}