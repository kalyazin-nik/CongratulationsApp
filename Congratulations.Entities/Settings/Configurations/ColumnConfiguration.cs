using Congratulations.Entities.Settings.Models;

namespace Congratulations.Entities.Settings.Configurations;

internal static class ColumnConfiguration
{
    private static readonly Dictionary<string, Column> _columns = [];

    internal static Dictionary<string, Column> Columns => _columns;
}
