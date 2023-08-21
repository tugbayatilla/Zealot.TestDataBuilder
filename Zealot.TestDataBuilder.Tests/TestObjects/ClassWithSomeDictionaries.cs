namespace Zealot.Tests.TestObjects;

internal class ClassWithSomeDictionaries
{
    public Dictionary<object, object> ObjectAndObjectProp { get; set; }
    public Dictionary<string, int> StringAndIntProp { get; set; }
    public IReadOnlyDictionary<string, int> StringAndIntReadOnlyProp { get; set; }
}
