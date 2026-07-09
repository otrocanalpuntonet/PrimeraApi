using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _service;

    public CountriesController(ICountryService service)
    {
        _service = service;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _service.GetCountriesAsync();
        return Ok(countries);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountry(int id)
    {
        var country = await _service.GetCountryAsync(id);

        return Ok(country);
    }
}
