namespace Zealot.Tests.TestObjects;

internal class ClassWithThreeClassRecursively
{
    internal class A
    {
        public string Name { get; set; }

        public B RefB { get; set; }
    }

    internal class B
    {
        public string Name { get; set; }
        public C RefC { get; set; }
    }

    internal class C
    {
        public string Name { get; set; }
        public A RefA { get; set; }
        public List<A> RefAList { get; set; }
    }
}
