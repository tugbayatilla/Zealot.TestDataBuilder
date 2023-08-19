namespace Zealot.Interfaces;

internal interface IWithRecursionLevel
{
    bool CanContinueDeeper(IContext context, Type type);
    void SetAllowedRecursionLevel(int allowedRecursionLevel);
}
