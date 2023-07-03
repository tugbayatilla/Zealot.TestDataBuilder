namespace Zealot.Interfaces;

public interface IWithRecursionLevel
{
    bool CanContinueDeeper(Type type);
    void Register(Type type);
    void SetAllowedRecursionLevel(int allowedRecursionLevel);
}