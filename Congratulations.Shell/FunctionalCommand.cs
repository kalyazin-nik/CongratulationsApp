namespace Congratulations.Shell;

internal static class FunctionalCommand
{
    internal static readonly List<string> MenyItems =
    [
        "[п] Переключиться в главное меню",
        "[о] Отобразить список сотрудников",
        "[с] Создать новую запись о сотруднике",
        "[р] Редактировать заипсь о сотруднике",
        "[у] Удалить запись о сотрудника",
        string.Empty
    ];

    internal static readonly List<string> CongratulateItems =
    [
        "[п] Поздравить сотрудника",
        "[б] Ближайшие дни рождения",
        "[н] Неотмеченные дни рождения",
        string.Empty
    ];
}
