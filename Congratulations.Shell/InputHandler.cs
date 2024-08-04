using Congratulations.Shell.Windows;

namespace Congratulations.Shell;

internal static class InputHandler
{
    internal static bool CheckKyeInput(ConsoleKeyInfo keyInfo)
    {
        return keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.DisplaySubmenu(FunctionalCommand.MenyItems, 1, 40, "CheckKyeInputFromMenu"),
            ConsoleKey.F2 => Terminal.DisplaySubmenu(FunctionalCommand.CongratulateItems, 12, 31, "CheckKyeInputFromCongratulateMenu"),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            _ => Terminal.SaveInBuffer(keyInfo),
        };
    }

    internal static bool CheckKyeInputFromMenu(ConsoleKeyInfo keyInfo)
    {
        return keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.DisplaySubmenu(FunctionalCommand.MenyItems, 1, 40, "CheckKyeInputFromMenu"),
            ConsoleKey.F2 => Terminal.DisplaySubmenu(FunctionalCommand.CongratulateItems, 12, 31, "CheckKyeInputFromCongratulateMenu"),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            ConsoleKey.G => Terminal.DisplayBarMenu(nameof(MenuBar.WorkingArea), MenuBar.MIN_LENGTH_WORKING_AREA),
            ConsoleKey.J => Terminal.DisplayBarMenu(nameof(MenuBar.EmployeeListMenu), MenuBar.MIN_LENGTH_EMPLOYEE_LIST),
            ConsoleKey.C => Terminal.DisplayBarMenu(nameof(MenuBar.CreateRecordEmployeeMenu), MenuBar.MIN_LENGTH_CREATE_RECORD_EMPLOYEE/*, "CheckKeyInputFromCreateEmployee"*/),
            ConsoleKey.H => Terminal.DisplayBarMenu(nameof(MenuBar.UpdateRecordEmployeeMenu), MenuBar.MIN_LENGTH_UPDATE_RECORD_EMPLOYEE),
            ConsoleKey.E => Terminal.DisplayBarMenu(nameof(MenuBar.DeleteRecordEmployeeMenu), MenuBar.MIN_LENGTH_DELETE_RECORD_EMPLOYEE),
            _ => false
        };
    }

    internal static bool CheckKyeInputFromCongratulateMenu(ConsoleKeyInfo keyInfo)
    {
        return keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.DisplaySubmenu(FunctionalCommand.MenyItems, 1, 40, "CheckKyeInputFromMenu"),
            ConsoleKey.F2 => Terminal.DisplaySubmenu(FunctionalCommand.CongratulateItems, 12, 31, "CheckKyeInputFromCongratulateMenu"),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            ConsoleKey.G => Terminal.DisplayBarMenu(nameof(MenuBar.CongratulateEmployee), MenuBar.MIN_LENGTH_CONGRATULATE_EMPLOYEE),
            ConsoleKey.OemComma => Terminal.DisplayBarMenu(nameof(MenuBar.UpcomingBirthdays), MenuBar.MIN_LENGTH_UPCOMING_BIRTHDAYS),
            ConsoleKey.Y => Terminal.DisplayBarMenu(nameof(MenuBar.UnmarkedBirthdays), MenuBar.MIN_LENGTH_UNMARCED_BIRTHDAYS),
            _ => false
        };
    }

    internal static bool CheckKeyInputFromCreateEmployee(ConsoleKeyInfo keyInfo)
    {
        return keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.DisplaySubmenu(FunctionalCommand.MenyItems, 1, 40, "CheckKyeInputFromMenu"),
            ConsoleKey.F2 => Terminal.DisplaySubmenu(FunctionalCommand.CongratulateItems, 12, 31, "CheckKyeInputFromCongratulateMenu"),
            ConsoleKey.F5 => CreateEmployee.Save(),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            _ => CreateEmployee.HandleInput(keyInfo)
        };
    }
}
