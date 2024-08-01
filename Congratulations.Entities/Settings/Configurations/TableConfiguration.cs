using Congratulations.Entities.Settings.Models;

namespace Congratulations.Entities.Settings.Configurations;

internal static class TableConfiguration
{
    private static readonly Dictionary<string, Table> _tables = new()
    {
        { "Employee", new Table("employees", "company") },
        { "Address", new Table("addresses", "company") },
        { "Phone", new Table("phones", "company") }
    };

    internal static Dictionary<string, Table> Tables => _tables;
}
