namespace Congratulations.Database.Models;

internal readonly struct Constraint(string name, string sql)
{
    internal readonly string Name = name;
    internal readonly string Sql = sql;
}
