using Congratulations.Database.Models;

namespace Congratulations.Database.Configurations;

internal static class TableConfiguration
{
    private static readonly Dictionary<string, Table> _tables = [];

    internal static Dictionary<string, Table> Tables => _tables;
}
