namespace Congratulations.Entities;

public sealed class Address(int employeeID, string country, string city, string street, string houseNumber, string? apartment) : BaseEntity
{
    public int ID { get; set; }
    public int EmployeeID { get; set; } = employeeID;
    public Employee? Employee { get; set; }
    public string Country { get; set; } = country;
    public string City { get; set; } = city;
    public string Street { get; set; } = street;
    public string HouseNumber { get; set; } = houseNumber;
    public string? Apartment { get; set; } = apartment;

    public override string ToString()
    {
        return string.Format("{2} {3}{4}. {1}. {0}.", Country, City, Street, HouseNumber, Apartment is null ? string.Empty : string.Format(", кв {0}", Apartment));
    }
}
