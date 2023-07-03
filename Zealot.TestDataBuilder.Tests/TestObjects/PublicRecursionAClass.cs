namespace Zealot.SampleBuilder.Tests.TestObjects;

public class PublicRecursionAClass
{
    public PublicRecursionBClass PublicRecursionBProp { get; set; }
}

public class PublicRecursionBClass
{
    public PublicRecursionAClass PublicRecursionAClassProp { get; set; }
}