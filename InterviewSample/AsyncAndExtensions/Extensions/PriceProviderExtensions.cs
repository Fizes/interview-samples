using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewSample.AsyncAndExtensions.Models;

namespace InterviewSample.AsyncAndExtensions.Extensions
{
    public static class PriceProviderExtensions
    {
        public static async Task<decimal> CalculateTotalPriceAsync(this PriceProvider source, IList<ProductInfo> products)
        {
            var pricesTasks = products.Select(x => source.CalculatePriceAsync(x));
            var prices = await Task.WhenAll(pricesTasks);

            return prices.Sum();
        }
    }
}