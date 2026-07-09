using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public class UpdateEmployeeDto
{
    //[Required]
    public Guid Id { get; set; }
    //[Required]
    public string Name { get; set; } = string.Empty;
    public string? Position { get; set; }
    //[Required]
    //[Range(1, int.MaxValue, ErrorMessage = "CountryId debe ser mayor a 0")]
    public int CountryId { get; set; }
    //[Required]
    public bool Active { get; set; }
}