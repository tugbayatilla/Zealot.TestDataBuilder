namespace Zealot.Tests.TestObjects;

internal class ClassOfGod
{
    public List<ClassWithOnePropertyWithoutSetter> SampleDataSimpleSubClassList { get; set; }
    public IList<ClassWithOnePropertyWithoutSetter> SampleDataSimpleSubClassIListInterface { get; set; }
    public ICollection<ClassWithOnePropertyWithoutSetter> SampleDataSimpleSubClassICollectionInterface { get; set; }
    public IEnumerable<ClassWithOnePropertyWithoutSetter> SampleDataSimpleSubClassIEnumerableInterface { get; set; }

    #region Classes

    public ClassWithOnePropertyWithoutSetter ClassWithOnePropertyWithoutSetter { get; set; }
    public ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger { get; set; }
    public ClassWithOneDateTimeInConstructor ClassWithOneDateTimeInConstructor { get; set; }
    public ClassWithPrivateConstructor ClassWithPrivateConstructorProp { get; set; }

    #endregion

    #region Primitives / Value Types

    public int IntProperty { get; set; }
    public int? IntPropertyNullable { get; set; }
    public short Int16Property { get; set; }
    public short? Int16PropertyNullable { get; set; }
    public long Int64Property { get; set; }
    public long? Int64PropertyNullable { get; set; }
    public uint UIntProperty { get; set; }
    public uint? UIntPropertyNullable { get; set; }
    public ushort UInt16Property { get; set; }
    public ushort? UInt16PropertyNullable { get; set; }
    public ulong UInt64Property { get; set; }
    public ulong? UInt64PropertyNullable { get; set; }
    public decimal DecimalProperty { get; set; }
    public decimal? DecimalPropertyNullable { get; set; }
    public float FloatProperty { get; set; }
    public float? FloatPropertyNullable { get; set; }
    public double DoubleProperty { get; set; }
    public double? DoublePropertyNullable { get; set; }
    public float SingleProperty { get; set; }
    public float? SinglePropertyNullable { get; set; }
    public byte ByteProperty { get; set; }
    public byte? BytePropertyNullable { get; set; }
    public DateTime DateTimeProperty { get; set; }
    public DateTime? DateTimePropertyNullable { get; set; }
    public bool BooleanProperty { get; set; }
    public bool? BooleanPropertyNullable { get; set; }
    public string StringProperty { get; set; }
    public string StringPropertyNullable { get; set; }
    public Guid GuidProperty { get; set; }
    public Guid GuidPropertyNullable { get; set; }

    #endregion
}
