using System.Linq;
using System.Threading.Tasks;
using InterviewSample.ApiIntegration.Models;
using InterviewSample.ApiIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSample.Controllers
{
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        // Задача 1:
        // 1. добавить апи списка стран
        // 2. нужно брать их со ссылки https://api.worldremit.com/api/countries
        // 3. вернуть список айди и имени, убрать из списка австрию

        // Задача 2:
        // Сделать динамическое отключение и включение стран
        // Например: в пятницу мы отключаем германию, а в субботу нужно включить австрию

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("countries/")]
        public async Task<ActionResult<GetAvailableCountriesResponse>> GetCountries()
        {
            var countries = await _countryService.GetAvailableCountries();
            return new GetAvailableCountriesResponse
            {
                // Select или через маппер
                Items = countries.Select(c => new GetAvailableCountriesResponseItem
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
            };
        }
    }
}