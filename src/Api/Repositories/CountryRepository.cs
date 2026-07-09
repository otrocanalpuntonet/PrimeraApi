using Api.ApiDbContext;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetCountries()
    {
        return await _context.Countries.ToListAsync();
    }

    public async Task<Country?> GetCountry(int id)
    {
        return await _context.Countries.FindAsync(id);
    }
}