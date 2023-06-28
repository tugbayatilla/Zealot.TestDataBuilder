﻿using System.Collections;
using System.Reflection;

namespace Zealot.Strategies;

public class ListStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
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

    public IEnumerable<Type> AvailableTypes =>
        new[]
        {
            typeof(IList<>),
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
}