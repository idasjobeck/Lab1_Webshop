using System.Text.Json;
using WebshopBackend.DtoExtensions;
using WebshopBackend.DTOs;
using WebshopCore.Dtos;

namespace WebshopBackend.ApiEndpoints
{
    public class ExchangeRateEndpoints
    {
        public async Task<ExchangeRateDto> GetExchangeRateAsync(string baseCurrency, string newCurrency, IConfiguration configuration)
        {
            using var client = new HttpClient();
            var data = await client.GetStringAsync($"https://v6.exchangerate-api.com/v6/{configuration["ExchangeRateApiKey"]}/pair/{baseCurrency}/{newCurrency}");
            var exchangeRateApiDto = JsonSerializer.Deserialize<ExchangeRateApiDto>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return exchangeRateApiDto.ToExchangeRateDto();
        }
    }
}
