using Core.Enums;


namespace Core.Models.Domain;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
    public EmployeeStatus Status { get; set; }
}
