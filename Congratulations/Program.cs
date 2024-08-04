using Congratulations.Factories;
using Congratulations.Shell;
using Congratulations.Tasks;

namespace Congratulations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeHandler.SetDataContext(DbContextFactory.CreateDataContext());
            var shell = new WorkWidow();
            var employeeTask = new EmployeeTask();

            shell.Run();
            employeeTask.Reader.Start();
            employeeTask.Created.Start();
        }
    }
}
