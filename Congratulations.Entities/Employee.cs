namespace Congratulations.Entities;

public sealed class Employee(string name, string surname, string patronymic, DateTime birthday) : BaseEntity
{
    public int ID { get; set; }
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Patronymic { get; set; } = patronymic;
    public DateTime Birthday { get; set; } = birthday;
    public Address? Address { get; set; }
    public List<Phone> Phone { get; set; } = [];
    public int Age => GetAge();

    public override string ToString()
    {
        return string.Format("код {0}. {2} {1} {3}", ID, Name, Surname, Patronymic);
    }

    private int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - Birthday.Year;

        return Birthday.Date > today.AddYears(-age) ? --age : age;
    }
}
