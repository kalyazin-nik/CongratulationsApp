namespace Congratulations.Shell.Windows;

public static class CreateEmployee
{
    private static readonly List<string> _lines =
    [
        new string(' ', 60),
        string.Format($"{new string(' ', 6)}Введите фамилию{new string(' ', 39)}"),
        new string(' ', 60),
        new string(' ', 60),
        string.Format($"{new string(' ', 6)}Введите имя{new string(' ', 43)}"),
        new string(' ', 60),
        new string(' ', 60),
        string.Format($"{new string(' ', 6)}Введите отчество{new string(' ', 38)}"),
        new string(' ', 60),
        new string(' ', 60),
        string.Format($"{new string(' ', 6)}Введите дату рождения (пример 1.1.1990){new string(' ', 15)}"),
        new string(' ', 60),
        new string(' ', 60),
        new string(' ', 60),
        string.Format($"{new string(' ', 42)}Сохранить F5{new string(' ', 6)}"),
        new string(' ', 60)
    ];

    private static readonly string _inputField = new string(' ', 48);
    private static int[] _cursorPosition = [12, 6];

    public static bool IsSave { get; private set; } = false;
    public static string[] EmployeeInfo { get; private set; } = [];

    public static bool Show()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.CursorTop = 4;
        _cursorPosition = [12, 6];

        foreach (var line in _lines)
        {
            Console.CursorLeft = 6;
            Console.WriteLine(line);
        }

        Console.BackgroundColor = ConsoleColor.Gray;
        Console.CursorTop = 6;
        for (int i = 0; i < 4; i++)
        {
            Console.CursorLeft = 12;
            Console.WriteLine(_inputField);
            Console.CursorTop += 2;
        }

        Console.CursorVisible = true;
        return true;
    }

    internal static bool HandleInput(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            if (_cursorPosition[1] != 15)
            {
                Terminal.Buffer += "\n";
                _cursorPosition[1] += 3;
                Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
            }
            else
            {
                Console.SetCursorPosition(Terminal.Buffer.Split('\n')[3].Length + _cursorPosition[0], _cursorPosition[1]);
            }
        }
        else if (keyInfo.Key == ConsoleKey.Backspace)
        {
            var bufer = Terminal.Buffer;
            if (string.IsNullOrEmpty(bufer))
            {
                Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
                return true;
            }

            if (bufer.Last() == '\n')
            {
                _cursorPosition[1] -= 3;
                Console.SetCursorPosition(Terminal.Buffer.Split('\n')[(_cursorPosition[1] - 6) / 3].Length + _cursorPosition[0], _cursorPosition[1]);
                Terminal.Buffer = bufer.Remove(bufer.Length - 1);
            }
            else
            {
                Console.Write(' ');
                Console.CursorLeft--;
                Terminal.Buffer = bufer.Remove(bufer.Length - 1);
            }
        }
        else
        {
            Terminal.Buffer += keyInfo.KeyChar;
        }
        return true;
    }

    internal static bool ShowContentInBuffer()
    {
        ChangeInputField();

        var lines = Terminal.Buffer.Split("\n");
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line) && lines.Length == 1)
            {
                break;
            }

            Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
            Console.Write(line);
            _cursorPosition[1] += 3;
        }

        if (_cursorPosition[1] == 18) _cursorPosition[1] -= 3;

        return true;
    }

    private static void ChangeInputField()
    {
        _cursorPosition = [12, 6];
        Console.SetCursorPosition(_cursorPosition[0], _cursorPosition[1]);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Gray;
    }

    internal static bool Save()
    {
        EmployeeInfo = Terminal.Buffer.Split('\n');
        IsSave = true;

        MenuBar.ActiveMenuBarName = "WorkingArea";
        return Terminal.RefreshScreen();
    }

    public static void UnchekedIsSave()
    {
        EmployeeInfo = [];
        IsSave = false;
    }
}
