using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Withs;

internal class WithGuid : IWithGuid
{
    public Guid Guid { get; set; } = Guid.NewGuid();
}
