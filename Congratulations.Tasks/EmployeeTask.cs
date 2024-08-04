using Congratulations.Shell.Windows;

namespace Congratulations.Tasks;

public class EmployeeTask
{
    public Task Created { get; private set; }
    public Task Reader { get; private set; }
    private bool _validate = true;

    public EmployeeTask()
    {
        Created = new Task(ExecuteSaveNewRecord);
        Reader = new Task(ExecuteShowRecords);
    }

    private void ExecuteSaveNewRecord()
    {
        while (true)
        {
            if (CreateEmployee.IsSave)
            {
                var employeeInfo = CreateEmployee.EmployeeInfo;
                if (DateTime.TryParse(employeeInfo[3], out var birthday))
                {
                    for (int i = 0; i < employeeInfo.Length; i++)
                    {
                        if (string.IsNullOrEmpty(employeeInfo[i]))
                        {
                            _validate = false;
                            WorkingArea.LogMessage += $"\n    Не удалось сохранить новую запись о сотруднике.\n" +
                                $"Поле \"{(i == 0 ? "Имя" : i == 1 ? "Фамилия" : i == 2 ? "Отчество" : "Дата рождения")}\" осталось пустым.";
                            break;
                        }
                    }

                    if (_validate)
                    {
                        EmployeeHandler.CreateEmployee(employeeInfo[0], employeeInfo[1], employeeInfo[2], birthday);
                        WorkingArea.LogMessage += $"\n    Новый сотрудник успешно добавлен.\n";
                    }
                }
                else
                {
                    WorkingArea.LogMessage += "\n    Не удалось сохранить новую запись о сотруднике.\nДата рождения некорректна.";
                }
                CreateEmployee.UnchekedIsSave();
            }

            _validate = true;
            Thread.Sleep(1000);
        }
    }

    private void ExecuteShowRecords()
    {
        while (true)
        {
            var employees = EmployeeHandler.ReadEmployees().Result;
            var employeesToString = new List<string>();

            foreach (var employee in employees)
            {
                employeesToString.Add(employee.ToString());
            }

            ReadEmployees.Employees = employeesToString;

            Thread.Sleep(1000);
        }
    }
}
