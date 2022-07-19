
using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Queries;
using Core.Enums;
using Core.Models.Domain;
using Core.Models.Requests;
using Core.Models.Responses;
using Core.Services;
using Dapper;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        //private readonly DapperContext _context;
        private readonly IMapper _mapper;
        private readonly IDbService _dbService;

        public EmployeeService( IMapper mapper, IDbService dbService)
        {
           // _context = dapper;
            _mapper = mapper;
            _dbService = dbService;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>(SQLQueries.GetEmployeeList, new { });
            return employeeList.ToList();
        }


        public async Task<bool> AddEmployee(EmployeeRequest employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            emp.Status = EmployeeStatus.NotDelete;
           
            await _dbService.InsertAsync(SQLQueries.AddEmployee, emp);

            return true;
            
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            var employeeList = await _dbService.GetAsync<Employee>(SQLQueries.GetEmployee, new { Id });

            await _dbService.UpdateAsync(SQLQueries.ChangeStatus, new { Status = EmployeeStatus.Delete, Id });
            return true;
            
        }

        public async Task<EmployeeResponse> GetEmployee(int Id)
        { 
            var employee = await _dbService.GetAsync<Employee>(SQLQueries.GetEmployee, new { Id });
            var emp = _mapper.Map<EmployeeResponse>(employee);
            return emp; 
        }

        public async Task<bool> UpdateEmployee(int Id, EmployeeRequest employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            emp.Id = Id;
            emp.Status = EmployeeStatus.NotDelete;

            await _dbService.UpdateAsync(SQLQueries.UpdateEmployee, emp);
            return true;
            
        }
    }
}
