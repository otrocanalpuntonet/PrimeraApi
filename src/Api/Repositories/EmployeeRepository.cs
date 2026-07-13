using Api.ApiDbContext;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Employee>> GetEmployeesAsync()
    {
        return _context.Employees;
    }

    public async Task<Employee?> GetEmployee(Guid id)
    {
        return await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new Employee
            {
                Id = e.Id,
                Name = e.Name,
                FotoUrl = e.FotoUrl,
                Position = e.Position,
                Active = e.Active,
                Country = new Country
                {
                    Id = e.Country.Id,
                    Name = e.Country.Name
                }
            })
            .FirstOrDefaultAsync();
    }

    public void AddEmployee(Employee employee)
    {
        _context.Add(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Update(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        _context.Remove(employee);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}