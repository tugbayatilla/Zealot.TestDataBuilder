namespace Zealot.SampleBuilder.Tests.TestObjects;

public class InheritedClass : BaseClass
{
    public string BaseStringProp { get; set; }
}

public class BaseClass
{
    public string StringProp1 { get; set; }
    public List<string> ListOfStringProp { get; set; }
    
}

public class ClassHavingAnotherClassAsProperty
{
    public InheritedClass InheritedClassProp { get; set; }

    public string Prop { get; set; }
}

public class ClassHavingIListInterfaceAsProperty
{
    // ReSharper disable once InconsistentNaming
    public IList<ClassHavingAnotherClassAsProperty> IListInterfaceProperty { get; set; }
}

internal class ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger : ClassWithTwoInteger
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

internal class SampleDataWithDictionary
{
    public Dictionary<object, object> DictionaryProperty { get; set; }
    public Dictionary<string, int> DictionaryStringIntProperty { get; set; }
}

//todo: support inheritance and parameters in constructor
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
