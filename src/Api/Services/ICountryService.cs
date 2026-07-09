using Api.Dto;

namespace Api.Services;

public interface ICountryService
{
    Task<IEnumerable<CountryDtoResult>> GetCountriesAsync();
    Task<CountryDtoResult?> GetCountryAsync(int id);
}