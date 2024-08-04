namespace Congratulations.Shell;

internal static class Terminal
{
    private static readonly ConsoleColor _defaultBackColor = Console.BackgroundColor;
    private static readonly ConsoleColor _defaultForeColor = Console.ForegroundColor;

    internal static int Width { get; set; }
    internal static int Height { get; set; }
    internal static string Buffer { get; set; } = null!;
    internal static bool IsNotExit { get; set; } = true;
    internal static bool IsShowMenu { get; set; } = false;
    internal static bool IsShowCongraturlate { get; set; } = false;
    internal static bool IsSizeChanged => Width != Console.WindowWidth || Height != Console.WindowHeight;

    internal static void ShowMenuBar()
    {
        while (IsNotExit)
        {
            if (IsSizeChanged)
            {
                ChangeSize();
                RefreshScreen();
            }
        }
    }

    internal static void CheckingInput()
    {
        while (IsNotExit)
        {
            if (IsShowMenu)
                InputHandler.CheckKyeInputFromMenu(Console.ReadKey(true));
            else if (IsShowCongraturlate)
                InputHandler.CheckKyeInputFromCongratulateMenu(Console.ReadKey(true));
            else
                InputHandler.CheckKyeInput(Console.ReadKey());
        }
    }

    private static void ChangeSize()
    {
        Width = Console.WindowWidth;
        Height = Console.WindowHeight;

        if (Width <= MenuBar.ActiveMenuBarMinLength)
        {
            Console.BufferWidth = MenuBar.ActiveMenuBarMinLength;
        }
    }

    internal static bool RefreshScreen()
    {
        Console.CursorVisible = true;
        IsShowMenu = false;
        IsShowCongraturlate = false;
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        _ = MenuBar.ActiveMenuBarName switch
        {
            "WorkingArea" => WriteLine(MenuBar.WorkingArea),
            "EmployeeListMenu" => WriteLine(MenuBar.EmployeeListMenu),
            "CreateRecordEmployeeMenu" => WriteLine(MenuBar.CreateRecordEmployeeMenu),
            "UpdateRecordEmployeeMenu" => WriteLine(MenuBar.UpdateRecordEmployeeMenu),
            "DeleteRecordEmployeeMenu" => WriteLine(MenuBar.DeleteRecordEmployeeMenu),
            "CongratulateEmployee" => WriteLine(MenuBar.CongratulateEmployee),
            "UpcomingBirthdays" => WriteLine(MenuBar.UpcomingBirthdays),
            "UnmarkedBirthdays" => WriteLine(MenuBar.UnmarkedBirthdays),
            _ => false
        };

        Console.CursorLeft = 1;
        Console.CursorTop = 2;

        Console.ForegroundColor = _defaultForeColor;
        Console.BackgroundColor = _defaultBackColor;

        Console.Write(Buffer);
        return true;
    }

    internal static bool ShowBarMenu(string menuName, int minLengthMenuName)
    {
        Buffer = string.Empty;
        MenuBar.ActiveMenuBarName = menuName;
        MenuBar.ActiveMenuBarMinLength = minLengthMenuName;

        RefreshScreen();
        return true;
    }

    internal static bool ShowSubmenu(List<string> items, int offset, int widthSubmenu, bool isShowMenu = false, bool isShowCongratulate = false)
    {
        RefreshScreen();
        IsShowMenu = isShowMenu;
        IsShowCongraturlate = isShowCongratulate;

        var cursorPosition = Console.GetCursorPosition();
        Console.CursorVisible = false;
        Console.CursorTop = 1;


        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;

        foreach (var item in items)
        {
            Console.CursorLeft = offset;
            Console.WriteLine($" {item}{new string(' ', widthSubmenu - item.Length)}");
        }

        Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

        Console.ForegroundColor = _defaultForeColor;
        Console.BackgroundColor = _defaultBackColor;
        return true;
    }

    private static bool WriteLine(string menuBar)
    {
        Console.WriteLine(menuBar);
        return true;
    }

    internal static bool MoveLine(ConsoleKeyInfo keyInfo)
    {
        Buffer += "\n";
        Console.WriteLine();
        Console.CursorLeft++;
        return true;
    }

    internal static bool SaveInBuffer(ConsoleKeyInfo keyInfo)
    {
        Buffer += $"{keyInfo.KeyChar}";
        return true;
    }

    internal static bool Exit()
    {
        return IsNotExit = false;
    }
}
