namespace Api.Dto;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? FotoUrl { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string ActiveLabel { get; init; } = string.Empty;
}