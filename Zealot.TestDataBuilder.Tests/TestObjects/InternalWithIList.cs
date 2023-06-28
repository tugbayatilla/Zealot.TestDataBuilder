using System.Collections;

namespace Zealot.SampleBuilder.Tests.TestObjects;

internal class InternalWithIListString
{
    public IList<string> IListStringProp { get; set; }
    public ICollection<string> ICollectionStringProp { get; set; }
    public ArrayList ArrayListProp { get; set; }
    public LinkedList<string> LinkedListStringProp { get; set; }
    public Queue<string> QueueStringProp { get; set; }
    public Queue QueueProp { get; set; }
}