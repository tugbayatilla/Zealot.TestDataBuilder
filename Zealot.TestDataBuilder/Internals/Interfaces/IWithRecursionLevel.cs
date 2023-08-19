namespace Zealot.Internals.Interfaces;

internal interface IWithRecursionLevel
{
    bool CanContinueDeeper(IContext context, Type type);
    void SetAllowedRecursionLevel(int allowedRecursionLevel);
}
