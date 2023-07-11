using Zealot.Interfaces;

namespace Zealot;

internal class WithGuid : IWithGuid
{
    public Guid Guid { get; set; } = Guid.NewGuid();
}