using Congratulations.Entities.Settings.Models;

namespace Congratulations.Entities.Settings.Configurations;

internal static class TableConfiguration
{
    private static readonly Dictionary<string, Table> _tables = [];

    internal static Dictionary<string, Table> Tables => _tables;
}
