namespace Congratulations.Shell.Windows;

public static class WorkingArea
{
    private static int[] _cursorPosition = null!;

    public static string LogMessage { get; set; } = string.Empty;

    internal static bool Show()
    {
        ChangeInputField();

        var lines = LogMessage.Split("\n");
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line) && lines.Length == 1)
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
