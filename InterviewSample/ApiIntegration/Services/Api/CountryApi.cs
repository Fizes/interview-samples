using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InterviewSample.ApiIntegration.Models;
using Newtonsoft.Json;

namespace InterviewSample.ApiIntegration.Services.Api
{
    public interface ICountryApi
    {
        Task<List<CountryApiModel>> GetCountriesAsync();
    }

    class CountryApi : ICountryApi
    {
        private const string WorldremitBaseAddress = "https://api.worldremit.com";

        public async Task<List<CountryApiModel>> GetCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WorldremitBaseAddress);
                var response = await client.GetAsync("/api/countries");
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CountryApiModel>>(body);
            }
        }
    }
}