using Api.Dto;
using Api.Parametros;

namespace Api.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDtoResult>> GetEmployeesAsync();
    Task<PagedResponse<EmployeeDtoResult>> GetAllAsync(RequestParameters parameters);
    Task<EmployeeDto?> GetEmployee(Guid id);
    Task<EmployeeDtoResult> AddEmployee(CreateEmployeeDto dto);
    Task UpdateEmployee(Guid id, UpdateEmployeeDto dto);
    Task DeleteEmployee(Guid id);
}
