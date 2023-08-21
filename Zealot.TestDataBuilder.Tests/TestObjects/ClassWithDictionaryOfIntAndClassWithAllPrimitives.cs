namespace Zealot.Tests.TestObjects;

internal class ClassWithDictionaryOfIntAndClassWithAllPrimitives
{
    public Dictionary<int, ClassWithAllPrimitives> Prop { get; set; }
}
