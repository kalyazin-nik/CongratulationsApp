namespace Congratulations.Entities.Settings.Models;

internal readonly struct Column(string name, string? type = null, string? defaultValueSql = null, bool hasIndex = false, bool isValueGeneratedNever = false, bool isIgnore = false)
{
    internal readonly string Name = name;
    internal readonly string? Type = type;
    internal readonly string? DefaultValueSql = defaultValueSql;
    internal readonly bool HasIndex = hasIndex;
    internal readonly bool IsValueGeneratedNever = isValueGeneratedNever;
    internal readonly bool IsIgnore = isIgnore;
}
