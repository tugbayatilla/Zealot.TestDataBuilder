namespace Zealot.SampleBuilder.Tests.TestObjects;

public class InheritedClass : BaseClass
{
    public bool IsForwarding { get; set; }
    public string Addressing { get; set; }
}

public class BaseClass
{
    public string Name { get; set; }

    public List<string> AdditionalLines { get; set; } = new List<string>();

    public string State { get; set; }

    public string County { get; set; }

    public string CountryIsoAlpha2Code { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }

    public string Street { get; set; }
}

public class ClassHavingArguments
{
    public ClassHavingArguments(string type, string value)
    {
        Type = type;
        Value = value;
    }

    public string Type { get; set; }

    public string Value { get; set; }

    public int Priority { get; set; } = 0;
}

public class ClassHavingNoArguments
{
    public string Type { get; set; }

    public string Value { get; set; }

    public int Priority { get; set; } = 0;
}

public class ClassHavingAnotherClassAsProperty
{
    public InheritedClass Address { get; set; }

    public string Id { get; set; }

    public string Fax { get; set; }

    public string Phone { get; set; }

    public string VatNumber { get; set; }

    public string CustomerGroup { get; set; }

    public string CustomerReference { get; set; }

    // IGUCUSTALTORDERACCOUNT
    public string AlternativeCustomerId { get; set; }
}

public class ClassHavingIListInterfaceAsProperty
{
    // ReSharper disable once InconsistentNaming
    public IList<ClassHavingAnotherClassAsProperty> IListInterfaceProperty { get; set; }
}

public class ClassHavingEnumProperty
{
    public SampleEnum SampleEnumProperty { get; set; }

    public enum SampleEnum
    {
        Value1,
        Value2 = 4,
        Value
    }
}

internal class SampleArrayPropertyClass
{
    public SampleDataClass[] SampleDataClassArray { get; set; }
    public SampleRecursiveListClass.A Recursive_A { get; set; }
}


public class SampleClassForUtilitiesTests
{
    public const string ConstantName = nameof(ConstantName);
    public const float ConstantFloat = 3.14f;

    public int? IntNullable { get; set; } = 1;

    public string Name2 { get; set; } = nameof(Name2);
    public string Name3 { get; } = nameof(Name3);
    public string Name4 { set; private get; } = nameof(Name4);

    public string Name5
    {
        set { value = nameof(Name5); }
    }

    internal string Name6 { get; set; } = nameof(Name6);
}

internal class SampleDataClass
{
    public List<SampleDataSimpleSubClass> SampleDataSimpleSubClassList { get; set; }
    public IList<SampleDataSimpleSubClass> SampleDataSimpleSubClassIListInterface { get; set; }
    public ICollection<SampleDataSimpleSubClass> SampleDataSimpleSubClassICollectionInterface { get; set; }
    public IEnumerable<SampleDataSimpleSubClass> SampleDataSimpleSubClassIEnumerableInterface { get; set; }

    #region Classes

    public SampleDataSimpleSubClass SampleDataSimpleSubClass { get; set; }
    public SampleDataInheritedSubClass SampleDataInheritedSubClass { get; set; }
    public SampleDataPrimitiveConstructorSubClass SampleDataPrimitiveConstructorSubClass { get; set; }
    public SampleDataPrivateConstructorSubClass SampleDataPrivateConstructorSubClass { get; set; }

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
    public string StringProperty { get; set; } = "";
    public string StringPropertyNullable { get; set; } = null;
    public Guid GuidProperty { get; set; }
    public Guid GuidPropertyNullable { get; set; } = Guid.Empty;

    #endregion
}

internal class SampleDataSimpleSubClass
{
    public int IntProperty { get; set; }
    public string StringProperty { get; set; }

    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string NoSetterProperty { get; }
}

internal class SampleDataInheritedSubClass : SampleDataSimpleSubClass
{
    public DateTime DateTimeProperty { get; set; }
}

internal class SampleDataPrimitiveConstructorSubClass
{
    public SampleDataPrimitiveConstructorSubClass(DateTime dateTime)
    {
        DateTimeProperty = dateTime;
    }

    public DateTime DateTimeProperty { get; set; }
}

/// <summary>
/// 
/// </summary>
internal class SampleDataPrivateConstructorSubClass
{
    private SampleDataPrivateConstructorSubClass()
    {
    }
}

/// <summary>
/// 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
internal class SampleDataClassForEquality
{
    public int IntValue { get; set; }

    public override bool Equals(object obj)
    {
        return IntValue == (obj as SampleDataClassForEquality)?.IntValue;
    }

    protected bool Equals(SampleDataClassForEquality other)
    {
        return IntValue == other.IntValue;
    }

    public override int GetHashCode()
    {
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        return IntValue.GetHashCode();
    }
}

internal class SampleDataWithDictionary
{
    public Dictionary<object, object> DictionaryProperty { get; set; }
    public Dictionary<string, int> DictionaryStringIntProperty { get; set; }
}

public class SampleEnumNoElementClass
{
    public SampleEnumNoElementEnum SampleEnumNoElementEnumProperty { get; set; }
}

public enum SampleEnumNoElementEnum
{
}

public class SampleNullableEnumClass
{
    public SampleNullableEnum? SampleNullableEnum { get; set; }
}

public enum SampleNullableEnum
{
    OnlyItem = 1,
    OnlyItem2 = 2,
}

internal class SampleRecursiveListClass
{
    internal class A
    {
        public string Name { get; set; }

        public B Ref_B { get; set; }
    }

    internal class B
    {
        public string Name { get; set; }
        public C Ref_C { get; set; }
    }

    internal class C
    {
        public string Name { get; set; }
        public A Ref_A { get; set; }
        public List<A> Ref_A_list { get; set; }
    }
}

public class SampleUser : SampleUserShort
{
    public SampleUser(SampleUserShort instaUserShort)
    {
        Pk = instaUserShort.Pk;
        UserName = instaUserShort.UserName;
        FullName = instaUserShort.FullName;
        IsPrivate = instaUserShort.IsPrivate;
        ProfilePicture = instaUserShort.ProfilePicture;
        ProfilePictureId = instaUserShort.ProfilePictureId;
        IsVerified = instaUserShort.IsVerified;
    }

    public bool HasAnonymousProfilePicture { get; set; }
    public int FollowersCount { get; set; }
    public string FollowersCountByLine { get; set; }
    public string SocialContext { get; set; }
    public string SearchSocialContext { get; set; }
    public int MutualFollowers { get; set; }
    public int UnseenCount { get; set; }
}

[Serializable]
public class SampleUserShort
{
    public bool IsVerified { get; set; }
    public bool IsPrivate { get; set; }
    public long Pk { get; set; }
    public string ProfilePicture { get; set; }
    public string ProfilePicUrl { get; set; }
    public string ProfilePictureId { get; set; } = "unknown";
    public string UserName { get; set; }
    public string FullName { get; set; }

    public static SampleUserShort Empty => new SampleUserShort {FullName = string.Empty, UserName = string.Empty};

    public bool Equals(SampleUserShort user)
    {
        return Pk == user?.Pk;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as SampleUserShort);
    }

    public override int GetHashCode()
    {
        return Pk.GetHashCode();
    }
}

public class SimpleClassWithStruct
{
    public SimpleStruct SimpleStruct { get; set; }
}

public struct SimpleStruct
{
    public string StringProp { get; set; }

    public bool BoolProp { get; set; }
}

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public DateTime FoundAt { get; set; }
    public DateTime? Closed { get; set; }
    public bool? IsBig { get; set; }
    public int? LocationCount { get; set; }
    public List<Branch> Branches { get; set; }
    public Branch MainBranch { get; set; }
    public Employee Owner { get; set; }
    public IEnumerable<Employee> SubWorkers { get; set; }
    public List<Employee> MainWorkers { get; set; }
    public Address MainAddress { get; set; }
}

public class Branch
{
    public Guid BranchId { get; set; }
    public uint EmployeeCount { get; set; }
    public decimal AverageSalary { get; set; }
}

public class MainBranch : Branch
{
    public bool HasBuilding { get; set; }
}

public class Employee
{
    public string Name { get; set; }
    public Company Company { get; set; }
}

public class Address
{
    public Address(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}