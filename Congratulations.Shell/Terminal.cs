using Congratulations.Shell.Windows;
using System.Runtime.CompilerServices;

namespace Congratulations.Shell;

internal static class Terminal
{
    private static readonly ConsoleColor _defaultBackColor = Console.BackgroundColor;
    private static readonly ConsoleColor _defaultForeColor = Console.ForegroundColor;

    internal static int Width { get; set; }
    internal static int Height { get; set; }
    internal static string Buffer { get; set; } = null!;
    internal static bool IsNotExit { get; set; } = true;
    internal static bool IsSizeChanged => Width != Console.WindowWidth || Height != Console.WindowHeight;
    public static string CheckingInputState { get; set; } = "CheckKyeInput";

    internal static void ShowMenuBar()
    {
        while (IsNotExit)
        {
            if (IsSizeChanged)
            {
                ChangeSize();
                RefreshScreen();
            }

            Thread.Sleep(2000);
            if (MenuBar.ActiveMenuBarName == "WorkingArea" && CheckingInputState == "CheckKyeInput")
            {
                RefreshScreen();
            }
        }
    }

    internal static void CheckingInput()
    {
        while (IsNotExit)
        {
            _ = CheckingInputState switch
            {
                "CheckKyeInput" => InputHandler.CheckKyeInput(Console.ReadKey(true)),
                "CheckKyeInputFromMenu" => InputHandler.CheckKyeInputFromMenu(Console.ReadKey(true)),
                "CheckKyeInputFromCongratulateMenu" => InputHandler.CheckKyeInputFromCongratulateMenu(Console.ReadKey(true)),
                "CheckKeyInputFromCreateEmployee" => InputHandler.CheckKeyInputFromCreateEmployee(Console.ReadKey()),
                _ => false
            };
        }
    }

    private static void ChangeSize()
    {
        Width = Console.WindowWidth;
        Height = Console.WindowHeight;
        Console.SetBufferSize(500, 1000);
    }

    internal static bool RefreshScreen()
    {
        var backColor = Console.BackgroundColor;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.BackgroundColor = backColor;

        _ = MenuBar.ActiveMenuBarName switch
        {
            "WorkingArea" => ShowWindow(MenuBar.WorkingArea),
            "EmployeeListMenu" => ShowWindow(MenuBar.EmployeeListMenu),
            "CreateRecordEmployeeMenu" => ShowWindow(MenuBar.CreateRecordEmployeeMenu),
            "UpdateRecordEmployeeMenu" => ShowWindow(MenuBar.UpdateRecordEmployeeMenu),
            "DeleteRecordEmployeeMenu" => ShowWindow(MenuBar.DeleteRecordEmployeeMenu),
            "CongratulateEmployee" => ShowWindow(MenuBar.CongratulateEmployee),
            "UpcomingBirthdays" => ShowWindow(MenuBar.UpcomingBirthdays),
            "UnmarkedBirthdays" => ShowWindow(MenuBar.UnmarkedBirthdays),
            _ => false
        };

        try
        {
            CheckingInputState = MenuBar.ActiveMenuBarName switch
            {
                "WorkingArea" => "CheckKyeInput",
                "CreateRecordEmployeeMenu" => "CheckKeyInputFromCreateEmployee",
                "EmployeeListMenu" => "CheckKyeInput"
            };
        }
        catch (SwitchExpressionException) { }

        _ = MenuBar.ActiveMenuBarName switch
        {
            "CreateRecordEmployeeMenu" => CreateEmployee.ShowContentInBuffer(),
            _ => false
        };

        return true;
    }

    internal static bool DisplayBarMenu(string menuName, int minLengthMenuName)
    {
        Buffer = string.Empty;
        MenuBar.ActiveMenuBarName = menuName;
        MenuBar.ActiveMenuBarMinLength = minLengthMenuName;

        RefreshScreen();
        return true;
    }

    internal static bool DisplaySubmenu(List<string> items, int offset, int widthSubmenu, string checkingInputState)
    {
        RefreshScreen();

        CheckingInputState = checkingInputState;
        Console.CursorVisible = false;
        Console.CursorTop = 1;


        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;

        var cursorPosition = Console.GetCursorPosition();
        foreach (var item in items)
        {
            Console.CursorLeft = offset;
            Console.WriteLine($" {item}{new string(' ', widthSubmenu - item.Length)}");
        }

        Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

        return true;
    }

    private static bool ShowWindow(string menuBar)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.CursorVisible = false;
        Console.WriteLine(menuBar);

        return MenuBar.ActiveMenuBarName switch
        {
            "WorkingArea" => WorkingArea.Show(),
            "EmployeeListMenu" => ReadEmployees.Show(),
            "CreateRecordEmployeeMenu" => CreateEmployee.Show(),
            _ => false
        };
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
