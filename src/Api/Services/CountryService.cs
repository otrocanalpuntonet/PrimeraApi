using Api.ApiDbContext;
using Api.Dto;
using Api.Repositories;

namespace Api.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _repository;

    public CountryService(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CountryDtoResult>> GetCountriesAsync()
    {
        var countries = await _repository.GetCountries();

        return countries.Select(country => new CountryDtoResult
        {
            Id = country.Id,
            Code = country.Code,
            Name = country.Name
        });
    }

    public async Task<CountryDtoResult?> GetCountryAsync(int id)
    {
        var country = await _repository.GetCountry(id) 
            ?? throw new Exception("País no encontrado");

        return new CountryDtoResult
        {
            Id = country.Id,
            Code = country.Code,
            Name = country.Name
        };
    }
}