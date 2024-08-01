using Congratulations.Entities.Settings.Models;

namespace Congratulations.Entities.Settings.Configurations;

internal static class ColumnConfiguration
{
    private static readonly Dictionary<string, Column> _columns = new()
    {
        { "ID", new Column("id", hasIndex: true) },
        { "Name", new Column("name", "varchar(20)") },
        { "Surname", new Column("surname", "varchar(20)") },
        { "Patronymic", new Column("patronymic", "varchar(20)") },
        { "Birthday", new Column("birthday", "date", hasIndex: true) },
        { "Age", new Column(string.Empty, isIgnore: true) },
        { "EmployeeID", new Column("employee_id", hasIndex: true) },
        { "Country", new Column("country", "varchar(20)") },
        { "City", new Column("city", "varchar(20)") },
        { "Street", new Column("street", "varchar(30)") },
        { "HouseNumber", new Column("house_number", "varchar(10)") },
        { "Apartment", new Column("apartment", "varchar(10)") },
        { "Number", new Column("number", hasIndex: true) }
    };

    internal static Dictionary<string, Column> Columns => _columns;
}
