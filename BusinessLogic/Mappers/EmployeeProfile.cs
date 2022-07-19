using AutoMapper;
using Core.Models.Domain;
using Core.Models.Requests;
using Core.Models.Responses;

namespace BusinessLogic.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeRequest>()
            .ReverseMap();

        CreateMap<EmployeeResponse, Employee>()
           .ReverseMap();
    }

    
        
}
