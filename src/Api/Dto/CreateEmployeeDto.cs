namespace Api.Dto;

public class CreateEmployeeDto
{   
    public string Name { get; set; } = string.Empty;
    public string? Position { get; set; }
    public int CountryId { get; set; }
    public IFormFile? Foto { get; set; }
}