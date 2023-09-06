using Zealot.Internals.Withs;

namespace Zealot.Internals.Interfaces;

internal interface IWithString
{
    string Prefix { get; set; }
    string Suffix { get; set; }
    SetValue<string> Body { get; set; }
    SetValue<string> Separator { get; set; }
    SetValue<int> StringUniqueStartNumber { get; set; }
}
