using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class SeriesDtoExtensions
    {
        public static Series ToSeries(this SeriesDto seriesDto) => new Series
        {
            Id = 0,
            SeriesName = seriesDto.SeriesName
        };

        public static Series ToSeries(this string series) => new Series
        {
            Id = 0,
            SeriesName = series
        };

        public static SeriesDto ToSeriesDto(this Series series) => new SeriesDto
        {
            SeriesName = series.SeriesName
        };

        public static SeriesDto ToSeriesDto(this string series) => new SeriesDto
        {
            SeriesName = series
        };
    }
}
