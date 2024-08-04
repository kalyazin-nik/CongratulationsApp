namespace Congratulations.Shell.Windows;

public class ReadEmployees
{
    private static int[] _cursorPosition = null!;

    public static List<string> Employees { get; set; } = null!;

    internal static bool Show()
    {
        if (Employees is null)
        {
            return false;
        }

        ChangeInputField();

        foreach (var line in Employees)
        {
            if (string.IsNullOrEmpty(line) && Employees.Count == 1)
            {
                break;
            }

            Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
            Console.Write($"  {line}{new string(' ', 60 - line.Length)}");
            _cursorPosition[1]++;
        }

        return true;
    }

    private static void ChangeInputField()
    {
        _cursorPosition = [4, 4];
        Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
        Console.BackgroundColor = ConsoleColor.DarkCyan;
    }
}
