using Zealot.Internals.Withs;

namespace Zealot.Internals.Interfaces;

internal interface IWithString
{
    SetValue<string> Body { get; }
    SetValue<int> StringUniqueStartingNumber { get; }
}
