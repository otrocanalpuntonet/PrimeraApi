using Api.Dto;
using Api.Models;
using Api.Parametros;
using Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IFileManagerxx _managerxx;

    public EmployeeService(IEmployeeRepository repository, IFileManagerxx managerxx)
    {
        _repository = repository;
        _managerxx = managerxx;
    }

    public async Task<EmployeeDtoResult> AddEmployee(CreateEmployeeDto dto)
    {
        var employeeModel = new Employee
        {
            Name = dto.Name,
            Position = dto.Position,
            CountryId = dto.CountryId,
            Active = true
        };

        if (dto.Foto is not null)
        {
            employeeModel.FotoUrl = await _managerxx.SaveFile("employees", dto.Foto.ConvertToFileDTO());
        }

        _repository.AddEmployee(employeeModel);
        await _repository.SaveChangesAsync();
        
        var employeeDto = new EmployeeDtoResult
        {
            Id = employeeModel.Id,
            Name = employeeModel.Name,
            Position = employeeModel.Position,
            Active = employeeModel.Active,
            CountryId = employeeModel.CountryId
        };

        return employeeDto;
    }

    public async Task<PagedResponse<EmployeeDtoResult>> GetAllAsync(RequestParameters parameters)
    {
       var query = await _repository.GetEmployeesAsync();

       var count = await query.CountAsync();

       var items = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                        .Take(parameters.PageSize)
                        . Select(x => new EmployeeDtoResult
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Position = x.Position,
                            Active = x.Active,
                            CountryId = x.CountryId
                        }
        ).ToListAsync();

        return new PagedResponse<EmployeeDtoResult>
        {
            Data = items,
            PageNumber = parameters.PageNumber,
            PageSize = parameters.PageSize,
            TotalCount = count
        };
    }

    public async Task DeleteEmployee(Guid id)
    {
        var employee = await _repository.GetEmployee(id) 
            ?? throw new Exception("Empleado no encontrado");

        _repository.DeleteEmployee(employee);

        await _repository.SaveChangesAsync();
    }

    public async Task<EmployeeDto?> GetEmployee(Guid id)
    {
        var employee = await _repository.GetEmployee(id) 
            ?? throw new Exception("Empleado no encontrado");

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            CountryName = employee.Country.Name,
            Position = employee.Position??"",
            FotoUrl = employee.FotoUrl,
            ActiveLabel = employee.Active ? "activo" : "inactivo"
        };
    }

    public async Task<IEnumerable<EmployeeDtoResult>> GetEmployeesAsync()
    {
        var employees = await _repository.GetEmployeesAsync();
        return employees.Select(x => new EmployeeDtoResult
        {
            Id = x.Id,
            Name = x.Name,
            Position = x.Position,
            Active = x.Active,
            CountryId = x.CountryId
        }).ToList();
    }

    public async Task UpdateEmployee(Guid id, UpdateEmployeeDto dto)
    {
        var employee = await _repository.GetEmployee(dto.Id);

        if (employee is null || id != dto.Id)
            throw new Exception("Empleado no encontrado");

        employee.Name = dto.Name;
        employee.Position = dto.Position;
        employee.CountryId = dto.CountryId;
        employee.Active = dto.Active;

        _repository.UpdateEmployee(employee);
        
        await _repository.SaveChangesAsync();
    }
}