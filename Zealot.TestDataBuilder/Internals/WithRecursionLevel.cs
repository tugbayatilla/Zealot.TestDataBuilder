using Zealot.Interfaces;

namespace Zealot.Internals;

internal class WithRecursionLevel : IWithRecursionLevel
{
    private int _allowedRecursionLevel;

    public bool CanContinueDeeper(IContext context, Type type)
    {
        var (exist, level) = RecursionExist(context, type);
        if (exist)
        {
            return level <= _allowedRecursionLevel;
        }

        return true;
    }

    private (bool exist, int level) RecursionExist(IContext context, Type type)
    {
        var level = 0;
        var exist = false;
        while (true)
        {
            // no parent, no recursion
            if (context.Parent == null) return (exist, level);
            
            // parent has same type, recursion
            if (context.Parent.Entity.GetType() == type)
            {
                exist = true;
                level++;
            }

            context = context.Parent;
        }
    }

    public void SetAllowedRecursionLevel(int allowedRecursionLevel)
    {
        _allowedRecursionLevel = allowedRecursionLevel;
    }
}