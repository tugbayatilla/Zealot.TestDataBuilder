using System.Collections;

namespace Zealot.Tests.TestObjects;

internal class ClassWithUnsupportedType
{
    public Dictionary<ICollection, object> Prop { get; set; }
}