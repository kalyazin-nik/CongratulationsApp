using Congratulations.Database.Models;

namespace Congratulations.Database.Configurations;

internal static class ColumnConfiguration
{
    private static readonly Dictionary<string, Column> _columns = [];

    internal static Dictionary<string, Column> Columns => _columns;
}
