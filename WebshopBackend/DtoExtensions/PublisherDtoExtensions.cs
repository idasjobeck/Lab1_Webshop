using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class PublisherDtoExtensions
    {
        public static Publisher ToPublisher(this PublisherDto publisherDto) => new Publisher
        {
            Id = 0,
            PublisherName = publisherDto.PublisherName
        };

        public static Publisher ToPublisher(this string publisher) => new Publisher
        {
            Id = 0,
            PublisherName = publisher
        };

        public static PublisherDto ToPublisherDto(this Publisher publisher) => new PublisherDto
        {
            PublisherName = publisher.PublisherName
        };

        public static PublisherDto ToPublisherDto(this string publisher) => new PublisherDto
        {
            PublisherName = publisher
        };
    }
}
