namespace Congratulations.Entities;

public sealed class Phone(int employeeID, long number) : BaseEntity
{
    public int ID { get; set; }
    public int EmployeeID { get; set; } = employeeID;
    public Employee? Employee { get; set; }
    public long Number { get; set; } = number;

    public override string ToString()
    {
        return string.Format("{0:+# (###) ### - ## - ##}", Number);
    }
}
