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
            new WorkWidow().Run();
        }
    }
}
