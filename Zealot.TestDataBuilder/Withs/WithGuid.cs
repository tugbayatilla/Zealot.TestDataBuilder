using Zealot.Interfaces;

namespace Zealot.Withs;

internal class WithGuid : IWithGuid
{
    public Guid Guid { get; set; } = Guid.NewGuid();
}