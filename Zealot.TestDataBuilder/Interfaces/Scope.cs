namespace Zealot.Interfaces;

internal record Scope(Type EntityType, object? Entity, string? ParentPropertyName, Scope? Parent);