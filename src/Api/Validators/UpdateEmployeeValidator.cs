using Api.Dto;
using Api.Models;
using FluentValidation;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace Api.Validators;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("El id no puder ser nulo");
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre no puder ser nulo");
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("el campo id no puede estar vacio")
            .GreaterThan(0)
            .WithMessage("El id no puder ser cero");
        RuleFor(x => x.Position)
            .NotEmpty()
            .IsEnumName(typeof(EmployeePosition), caseSensitive: false);
    }
}