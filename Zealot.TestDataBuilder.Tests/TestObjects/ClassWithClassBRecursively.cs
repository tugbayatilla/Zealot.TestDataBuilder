namespace Zealot.Tests.TestObjects;

internal class ClassWithClassBRecursively
{
    public ClassWithClassARecursively Prop { get; set; }
    
    public class ClassWithClassARecursively
    {
        public ClassWithClassBRecursively Prop { get; set; }
    }
}
