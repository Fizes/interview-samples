using System.Collections.Generic;

namespace InterviewSample.ApiIntegration.Models
{
    public class GetAvailableCountriesResponse
    {
        public IList<GetAvailableCountriesResponseItem> Items { get; set; }
    }

    public class GetAvailableCountriesResponseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}