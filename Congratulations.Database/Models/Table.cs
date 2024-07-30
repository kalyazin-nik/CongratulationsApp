namespace Congratulations.Database.Models;

internal readonly struct Table(string name, string? schema = null, Constraint[]? constraints = null)
{
    internal readonly string Name = name;
    internal readonly string? Schema = schema;
    internal readonly Constraint[]? Constraints = constraints;
}
