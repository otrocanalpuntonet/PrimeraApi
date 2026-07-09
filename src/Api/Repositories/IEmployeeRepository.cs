using Api.Models;

namespace Api.Repositories;

public interface IEmployeeRepository
{
    Task<IQueryable<Employee>> GetEmployeesAsync();
    Task<Employee?> GetEmployee(Guid id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
    Task SaveChangesAsync();
}