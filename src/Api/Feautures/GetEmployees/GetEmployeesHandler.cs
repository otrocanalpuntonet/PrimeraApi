using Api.Dto;
using Api.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Feautures.GetEmployees;

public class GetEmployeesHandler : IRequestHandler<GetEmployeeRequest, PagedResponse<EmployeeDtoResult>>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeesHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<EmployeeDtoResult>> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
    {
        var parameters = request.Parameters;

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
}