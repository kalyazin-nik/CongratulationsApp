namespace Congratulations.Database.Models;

internal readonly struct Column(string name, string? type = null, string? defaultValueSql = null, bool isValueGeneratedNever = false)
{
    internal readonly string Name = name;
    internal readonly string? Type = type;
    internal readonly string? DefaultValueSql = defaultValueSql;
    internal readonly bool IsValueGeneratedNever = isValueGeneratedNever;
}
