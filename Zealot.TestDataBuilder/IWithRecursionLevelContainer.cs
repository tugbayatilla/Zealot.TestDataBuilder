namespace Zealot;

public interface IWithRecursionLevelContainer
{
    bool CanContinueDeeper(Type type);
    void Register(Type type);
    void SetAllowedRecursionLevel(int allowedRecursionLevel);
}