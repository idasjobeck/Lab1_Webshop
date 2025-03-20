using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class EditionDtoExtensions
    {
        public static Edition ToEdition(this EditionDto editionDto) => new Edition
        {
            Id = 0,
            EditionName = editionDto.EditionName
        };

        public static Edition ToEdition(this string edition) => new Edition
        {
            Id = 0,
            EditionName = edition
        };

        public static EditionDto ToEditionDto(this Edition edition) => new EditionDto
        {
            EditionName = edition.EditionName
        };

        public static EditionDto ToEditionDto(this string edition) => new EditionDto
        {
            EditionName = edition
        };
    }
}
