namespace Zealot.Interfaces;

public interface IWithRecursionLevel
{
    bool CanContinueDeeper(IContext context, Type type);
    void SetAllowedRecursionLevel(int allowedRecursionLevel);
}
