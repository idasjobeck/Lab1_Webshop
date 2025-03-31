using WebshopBackend.DTOs;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class ExchangeRateDtoExtensions
    {
        public static ExchangeRateDto ToExchangeRateDto(this ExchangeRateApiDto exchangeRateApiDto) => new ExchangeRateDto
        {
            ConversionRate = exchangeRateApiDto.ConversionRate
        };
    }
}
