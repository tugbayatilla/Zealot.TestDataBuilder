namespace Zealot.Tests.TestObjects;

public class ClassHavingAnotherClassAsProperty
{
    public ClassWithInheritance ClassWithInheritanceProp { get; set; }

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


internal class ClassWithoutParameterlessConstructor
{
    public ClassWithoutParameterlessConstructor(ClassWithTwoString argument)
    {
        Prop1 = argument.Prop1;
        Prop2 = argument.Prop2;
    }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
}
