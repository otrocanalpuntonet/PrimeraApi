using Api.Dto;
using Api.Parametros;
using MediatR;

namespace Api.Feautures.GetEmployees;

public record GetEmployeeRequest(RequestParameters Parameters)
    : IRequest<PagedResponse<EmployeeDtoResult>>;