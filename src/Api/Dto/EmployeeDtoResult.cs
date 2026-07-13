namespace Api.Dto;

public class EmployeeDtoResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Position { get; set; }
    public string? FotoUrl { get; set; }
    public bool Active { get; set; } = true;
    public int CountryId { get; set; }
}