using Zealot.Internals.Withs;

namespace Zealot.Internals.Interfaces;

internal interface IWithString
{
    string Prefix { get; set; }
    string Suffix { get; set; }
    StringBody Body { get; set; }
    StringSeparator Separator { get; set; }
}