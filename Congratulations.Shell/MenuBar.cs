namespace Congratulations.Shell;

internal static class MenuBar
{
    private const string MENU = "Меню F1";
    private const string CONGRATULATE = "Поздравить F2";
    private const string REFRESH = "Обновить F9";
    private const string EXIT = "Выход F10";

    private const string WHITE_SPACE_2 = "  ";
    private const string WHITE_SPACE_4 = "    ";
    private const int SUM_CONST_WHITE_SPACES = 8;
    private const int SUM_MIN_COUNT_WHITE_SPACES = 12;

    private const string WORKING_AREA = "Рабочая область";
    private const string EMPLOYEE_LIST = "Отображение списка сотрудников";
    private const string CREATE_RECORD_EMPLOYEE = "Добавление записи о сотруднике";
    private const string UPDATE_RECORD_EMPLOYEE = "Редактирование записи о сотруднике";
    private const string DELETE_RECORD_EMPLOYEE = "Удаление записи о сотруднике";
    private const string CONGRATULATE_EMPLOYEE = "Поздравление сотрудника";
    private const string UPCOMING_BIRTHDAYS = "Ближайшие дни рождения";
    private const string UNMARKED_BIRTHDAYS = "Неотмеченные дни рождения";

    internal const int MIN_LENGTH_WORKING_AREA = 76;
    internal const int MIN_LENGTH_EMPLOYEE_LIST = 90;
    internal const int MIN_LENGTH_CREATE_RECORD_EMPLOYEE = 90;
    internal const int MIN_LENGTH_UPDATE_RECORD_EMPLOYEE = 96;
    internal const int MIN_LENGTH_DELETE_RECORD_EMPLOYEE = 88;
    internal const int MIN_LENGTH_CONGRATULATE_EMPLOYEE = 84;
    internal const int MIN_LENGTH_UPCOMING_BIRTHDAYS = 84;
    internal const int MIN_LENGTH_UNMARCED_BIRTHDAYS = 86;

    internal static string ActiveMenuBarName { get; set; } = nameof(WorkingArea);
    internal static int ActiveMenuBarMinLength { get; set; } = MIN_LENGTH_WORKING_AREA;

    internal static string WorkingArea => GetMenuString(WORKING_AREA, MIN_LENGTH_WORKING_AREA);
    internal static string EmployeeListMenu => GetMenuString(EMPLOYEE_LIST, MIN_LENGTH_EMPLOYEE_LIST);
    internal static string CreateRecordEmployeeMenu => GetMenuString(CREATE_RECORD_EMPLOYEE, MIN_LENGTH_CREATE_RECORD_EMPLOYEE);
    internal static string UpdateRecordEmployeeMenu => GetMenuString(UPDATE_RECORD_EMPLOYEE, MIN_LENGTH_UPDATE_RECORD_EMPLOYEE);
    internal static string DeleteRecordEmployeeMenu => GetMenuString(DELETE_RECORD_EMPLOYEE, MIN_LENGTH_DELETE_RECORD_EMPLOYEE);
    internal static string CongratulateEmployee => GetMenuString(CONGRATULATE_EMPLOYEE, MIN_LENGTH_CONGRATULATE_EMPLOYEE);
    internal static string UpcomingBirthdays => GetMenuString(UPCOMING_BIRTHDAYS, MIN_LENGTH_UPCOMING_BIRTHDAYS);
    internal static string UnmarkedBirthdays => GetMenuString(UNMARKED_BIRTHDAYS, MIN_LENGTH_UNMARCED_BIRTHDAYS);

    private static string GetMenuString(string menuName, int minLengthMenu)
    {
        var lengthWhiteSpace = Terminal.Width > minLengthMenu ? 
            Terminal.Width - MENU.Length - CONGRATULATE.Length - menuName.Length - REFRESH.Length - EXIT.Length - SUM_MIN_COUNT_WHITE_SPACES : 
            SUM_CONST_WHITE_SPACES;

        return string.Format(
            $"{WHITE_SPACE_2}" +
            $"{MENU}" +
            $"{WHITE_SPACE_4}" +
            $"{CONGRATULATE}" +
            $"{new string(' ', lengthWhiteSpace / 2)}" +
            $"{menuName}" +
            $"{new string(' ', (lengthWhiteSpace % 2 == 0 ? lengthWhiteSpace / 2 : lengthWhiteSpace / 2 + 1))}" +
            $"{REFRESH}" +
            $"{WHITE_SPACE_4}" +
            $"{EXIT}" +
            $"{WHITE_SPACE_2}");
    }
}
