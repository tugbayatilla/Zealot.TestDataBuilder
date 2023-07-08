namespace Zealot.SampleBuilder.Tests.TestObjects.ArrayTestClasses;

internal class StringArrayTestClass
{
    public string[] StringArrayProp { get; set; }
}

internal class ByteArrayTestClass
{
    public byte[] ByteArrayProp { get; set; }
}

internal class IntArrayTestClass
{
    public int[] IntArrayProp { get; set; }
}

internal class BooleanArrayTestClass
{
    public bool[] BooleanArrayProp { get; set; }
}

internal class EnumArrayTestClass
{
    public EnumForArray[] EnumArrayProp { get; set; }
    
    internal enum EnumForArray
    {
        Item1,
        Item2
    }
}