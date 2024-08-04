using Congratulations.Database;
using Congratulations.Entities;
using Microsoft.EntityFrameworkCore;

namespace Congratulations.Tasks;

public static class EmployeeHandler
{
    private static DataContext DataContext { get; set; } = null!;

    public static void SetDataContext(DataContext dataContext)
    {
        DataContext = dataContext;
    }

    internal static async void CreateEmployee(string surname, string name, string patronymic, DateTime birthday)
    {
        var employee = new Employee(name, surname, patronymic, birthday);

        await DataContext.AddAsync(employee);
        await DataContext.SaveChangesAsync();
    }

    public static async Task<List<Employee>> ReadEmployees()
    {
        return await DataContext.Employees.ToListAsync();
    }

    public static async Task<bool> UpdateEmployee(int id)
    {
        var employee = DataContext.Employees.FirstOrDefault(e => e.ID == id);
        if (employee is not null)
        {
            var name = string.Empty;
            var surname = string.Empty;
            var patronymic = string.Empty;
            var birthday = DateTime.Today;

            await DataContext.AddAsync(employee);
            await DataContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public static async Task<bool> DeleteEmployee(int id)
    {
        var employee = DataContext.Employees.FirstOrDefault(e => e.ID == id);
        if (employee is not null)
        {
            DataContext.Employees.Remove(employee);
            await DataContext.SaveChangesAsync();

            return true;
        }

        return false;
    }
}
