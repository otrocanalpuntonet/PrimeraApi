using Api.Models;

namespace Api.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetCountries();
    Task<Country?> GetCountry(int id);
}