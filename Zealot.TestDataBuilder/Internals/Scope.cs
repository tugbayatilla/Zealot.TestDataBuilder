namespace Zealot.Internals;

internal record Scope(Type EntityType, object? Entity, string? ParentPropertyName, Scope? Parent);