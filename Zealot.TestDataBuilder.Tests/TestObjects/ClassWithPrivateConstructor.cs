using System.Diagnostics.CodeAnalysis;

namespace Zealot.Tests.TestObjects;

[SuppressMessage("Sonar", "S3453")]
internal abstract class ClassWithPrivateConstructor
{
    private ClassWithPrivateConstructor()
    {
    }
}
