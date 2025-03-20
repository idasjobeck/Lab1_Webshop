using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class TitleDtoExtensions
    {
        public static Title ToTitle(this TitleDto titleDto) => new Title
        {
            Id = 0,
            TitleName = titleDto.TitleName
        };

        public static Title ToTitle(this string title) => new Title
        {
            Id = 0,
            TitleName = title
        };

        public static TitleDto ToTitleDto(this Title title) => new TitleDto
        {
            TitleName = title.TitleName
        };

        public static TitleDto ToTitleDto(this string title) => new TitleDto
        {
            TitleName = title
        };
    }
}
