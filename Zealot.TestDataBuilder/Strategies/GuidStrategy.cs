﻿using System.Reflection;
using Zealot.Interfaces;

namespace Zealot.Strategies;

internal class GuidStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[]
    {
        typeof(Guid?),typeof(Guid),
    };

    public override object GenerateValue(IContext context, Type type)
    {
        return context.WithGuid;
    }
}