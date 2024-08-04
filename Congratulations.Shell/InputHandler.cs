namespace Congratulations.Shell;

internal static class InputHandler
{
    internal static void CheckKyeInput(ConsoleKeyInfo keyInfo)
    {
        _ = keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.ShowSubmenu(FunctionalCommand.MenyItems, 1, 40, isShowMenu: true),
            ConsoleKey.F2 => Terminal.ShowSubmenu(FunctionalCommand.CongratulateItems, 12, 31, isShowCongratulate: true),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            ConsoleKey.Enter => Terminal.MoveLine(keyInfo),
            //ConsoleKey.Backspace => () =>
            //{
            //    if (Console.CursorLeft >= 0)
            //    {
            //        _temp = _temp.Remove(_temp.Length - 1);
            //        RefreshScreen();
            //    }
            //    return true;
            //},
            _ => Terminal.SaveInBuffer(keyInfo),
        };
    }

    internal static void CheckKyeInputFromMenu(ConsoleKeyInfo keyInfo)
    {
        _ = keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.ShowSubmenu(FunctionalCommand.MenyItems, 1, 40, isShowMenu: true),
            ConsoleKey.F2 => Terminal.ShowSubmenu(FunctionalCommand.CongratulateItems, 12, 31, isShowCongratulate: true),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            ConsoleKey.G => Terminal.ShowBarMenu(nameof(MenuBar.WorkingArea), MenuBar.MIN_LENGTH_WORKING_AREA),
            ConsoleKey.J => Terminal.ShowBarMenu(nameof(MenuBar.EmployeeListMenu), MenuBar.MIN_LENGTH_EMPLOYEE_LIST),
            ConsoleKey.C => Terminal.ShowBarMenu(nameof(MenuBar.CreateRecordEmployeeMenu), MenuBar.MIN_LENGTH_CREATE_RECORD_EMPLOYEE),
            ConsoleKey.H => Terminal.ShowBarMenu(nameof(MenuBar.UpdateRecordEmployeeMenu), MenuBar.MIN_LENGTH_UPDATE_RECORD_EMPLOYEE),
            ConsoleKey.E => Terminal.ShowBarMenu(nameof(MenuBar.DeleteRecordEmployeeMenu), MenuBar.MIN_LENGTH_DELETE_RECORD_EMPLOYEE),
            _ => false
        };
    }

    internal static void CheckKyeInputFromCongratulateMenu(ConsoleKeyInfo keyInfo)
    {
        _ = keyInfo.Key switch
        {
            ConsoleKey.F1 => Terminal.ShowSubmenu(FunctionalCommand.MenyItems, 1, 40, isShowMenu: true),
            ConsoleKey.F2 => Terminal.ShowSubmenu(FunctionalCommand.CongratulateItems, 12, 31, isShowCongratulate: true),
            ConsoleKey.F9 => Terminal.RefreshScreen(),
            ConsoleKey.F10 => Terminal.Exit(),
            ConsoleKey.G => Terminal.ShowBarMenu(nameof(MenuBar.CongratulateEmployee), MenuBar.MIN_LENGTH_CONGRATULATE_EMPLOYEE),
            ConsoleKey.OemComma => Terminal.ShowBarMenu(nameof(MenuBar.UpcomingBirthdays), MenuBar.MIN_LENGTH_UPCOMING_BIRTHDAYS),
            ConsoleKey.Y => Terminal.ShowBarMenu(nameof(MenuBar.UnmarkedBirthdays), MenuBar.MIN_LENGTH_UNMARCED_BIRTHDAYS),
            _ => false
        };
    }
}
