namespace Zealot.Interfaces;

public record Scope(Type EntityType, object? Entity, string? ParentPropertyName, Scope? Parent);