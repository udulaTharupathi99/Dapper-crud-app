using Core.Models.Domain;
using Core.Models.Requests;
using Core.Models.Responses;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeList();
        Task<EmployeeResponse> GetEmployee(int id);
        Task<bool> AddEmployee(EmployeeRequest employee);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(int id, EmployeeRequest employee);
    }
}
