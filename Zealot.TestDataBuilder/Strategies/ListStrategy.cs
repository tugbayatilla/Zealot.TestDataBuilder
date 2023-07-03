﻿using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Strategies;

internal class ListStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var listType = propertyInfo.PropertyType;

        if (propertyInfo.PropertyType is {IsInterface: true, IsGenericType: true})
        {
            listType = typeof(List<>).MakeGenericType(propertyInfo.PropertyType.GenericTypeArguments);
        }

        var listInstance = Instance.Create(listType);
        propertyInfo.SetValue(context.Entity, listInstance);

        await Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(IList<>),
            typeof(IList),
            typeof(ICollection<>),
            typeof(ICollection),
            typeof(ArrayList),
            typeof(LinkedList<>),
            typeof(Queue<>),
            typeof(Queue),
            typeof(Stack),
            typeof(Stack<>),
            typeof(IEnumerable<>),
            typeof(IEnumerable),
            typeof(IReadOnlyCollection<>),
            typeof(IReadOnlyList<>)
        };
    
    public override Expression<Func<PropertyInfo, bool>> ResolveCondition 
        => info => AvailableTypes.Any(x=>x.Name == info.PropertyType.Name);
}
