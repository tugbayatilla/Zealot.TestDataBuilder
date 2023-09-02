using System.Diagnostics.CodeAnalysis;

namespace Zealot.Tests.TestObjects;

internal class ClassWithIntPtr
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")] 
    public IntPtr Prop { get; set; }
}
