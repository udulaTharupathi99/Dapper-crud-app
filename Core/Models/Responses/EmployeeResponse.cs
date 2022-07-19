

using Core.Enums;

namespace Core.Models.Responses;

public class EmployeeResponse
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
    public EmployeeStatus Status { get; set; }
}
