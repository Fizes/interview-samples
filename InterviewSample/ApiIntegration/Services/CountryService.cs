using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewSample.ApiIntegration.Models;
using InterviewSample.ApiIntegration.Services.Api;

namespace InterviewSample.ApiIntegration.Services
{
    public interface ICountryService
    {
        Task<IList<Country>> GetAvailableCountries();
    }

    class CountryService : ICountryService
    {
        private readonly ICountryApi _countryApi;

        private const string AustriaCode = "AT";

        public CountryService(ICountryApi countryApi)
        {
            _countryApi = countryApi;
        }

        public async Task<IList<Country>> GetAvailableCountries()
        {
            var result = await _countryApi.GetCountriesAsync();
            return result.Where(c => c.Code != AustriaCode).Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}