using System.Threading.Tasks;
using InterviewSample.AsyncAndExtensions.Models;

namespace InterviewSample.AsyncAndExtensions
{
    public class PriceProvider
    {
        public Task<decimal> CalculatePriceAsync(ProductInfo product)
        {
            return Task.FromResult(1m);
        }
    }
}