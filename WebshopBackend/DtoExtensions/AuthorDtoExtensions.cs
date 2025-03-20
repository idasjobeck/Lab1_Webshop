using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class AuthorDtoExtensions
    {
        public static Author ToAuthor(this AuthorDto authorDto) => new Author
        {
            Id = 0,
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName
        };

        public static List<Author> ToAuthors(this List<AuthorDto> authorDtos) => authorDtos.Select(ToAuthor).ToList();

        // This assumes that the string is in the format "FirstName LastName"
        // Would need to include some error handling if the string is not in this format
        public static Author ToAuthor(this string author)
        {
            var authorSplit = author.Split(' ');
            return new Author
            {
                Id = 0,
                FirstName = authorSplit[0],
                LastName = authorSplit[1]
            };
        }

        // This assumes that the string of authors is in the format "FirstName LastName, FirstName LastName, ..."
        // Would need to include some error handling if the string is not in this format, and to provide a way to handle other separators
        public static List<Author> ToAuthors(this string authors) => authors.Split(", ").Select(ToAuthor).ToList();

        public static AuthorDto ToAuthorDto(this Author author) => new AuthorDto
        {
            FirstName = author.FirstName,
            LastName = author.LastName
        };

        public static List<AuthorDto> ToAuthorDtos(this List<Author> authors) => authors.Select(ToAuthorDto).ToList();

        // This assumes that the string is in the format "FirstName LastName"
        // Would need to include some error handling if the string is not in this format
        public static AuthorDto ToAuthorDto(this string author)
        {
            var authorSplit = author.Split(' ');
            return new AuthorDto
            {
                FirstName = authorSplit[0],
                LastName = authorSplit[1]
            };
        }

        // This assumes that the string of authors is in the format "FirstName LastName, FirstName LastName, ..."
        // Would need to include some error handling if the string is not in this format, and to provide a way to handle other separators
        public static List<AuthorDto> ToAuthorDtos(this string authors) => authors.Split(", ").Select(ToAuthorDto).ToList();

        public static string ToAuthorsAsString(this List<Author> authors) => 
            string.Join(", ", authors.Select(a => $"{a.FirstName} {a.LastName}"));
    }
}
