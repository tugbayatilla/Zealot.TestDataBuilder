namespace Zealot.Tests.TestObjects;

public class ClassHavingAnotherClassAsProperty
{
    public ClassWithInheritance ClassWithInheritanceProp { get; set; }
}

public class ClassHavingIListInterfaceAsProperty
{
    // ReSharper disable once InconsistentNaming
    public IList<ClassHavingAnotherClassAsProperty> IListInterfaceProperty { get; set; }
}

internal class ClassWithOneDateTimeAndInheritingClassWithTwoInteger : ClassWithTwoInteger
{
    public DateTime DateTimeProperty { get; set; }
}