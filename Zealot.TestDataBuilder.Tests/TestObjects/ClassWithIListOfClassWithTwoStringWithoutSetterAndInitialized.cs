namespace Zealot.Tests.TestObjects;

internal class ClassWithIListOfClassWithTwoStringWithoutSetterAndInitialized
{
    public IList<ClassWithTwoString> Prop { get; } = new List<ClassWithTwoString>();
}
