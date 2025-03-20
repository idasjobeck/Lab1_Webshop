using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class GenreDtoExtensions
    {
        public static Genre ToGenre(this GenreDto genreDto) => new Genre
        {
            Id = 0,
            GenreName = genreDto.GenreName
        };

        public static Genre ToGenre(this string genre) => new Genre
        {
            Id = 0,
            GenreName = genre
        };

        public static GenreDto ToGenreDto(this Genre genre) => new GenreDto
        {
            GenreName = genre.GenreName
        };

        public static GenreDto ToGenreDto(this string genre) => new GenreDto
        {
            GenreName = genre
        };
    }
}
