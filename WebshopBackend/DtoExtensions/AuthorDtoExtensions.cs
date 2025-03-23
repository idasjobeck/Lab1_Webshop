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

        public static Author ToAuthor(this string author)
        {
            var authorSplit = author.Split(' ');

            if (authorSplit.Length < 2 || authorSplit.Length > 3)
                throw new ArgumentException(
                    "Author string must be in the format 'FirstName LastName' or 'FirstName Initial LastName");

            if (authorSplit.Length == 3)
                return new Author
                {
                    Id = 0,
                    FirstName = $"{authorSplit[0]} {authorSplit[1]}",
                    LastName = authorSplit[2]
                };

            return new Author
            {
                Id = 0,
                FirstName = authorSplit[0],
                LastName = authorSplit[1]
            };
        }

        public static List<Author> ToAuthors(this string authors)
        {
            if (authors.Contains(';'))
                return authors.Split("; ").Select(ToAuthor).ToList();

            return authors.Split(", ").Select(ToAuthor).ToList();
        }

        public static AuthorDto ToAuthorDto(this Author author) => new AuthorDto
        {
            FirstName = author.FirstName,
            LastName = author.LastName
        };

        public static List<AuthorDto> ToAuthorDtos(this List<Author> authors) => authors.Select(ToAuthorDto).ToList();

        public static AuthorDto ToAuthorDto(this string author)
        {
            var authorSplit = author.Split(' ');

            if (authorSplit.Length < 2 || authorSplit.Length > 3)
                throw new ArgumentException(
                    "Author string must be in the format 'FirstName LastName' or 'FirstName Initial LastName");

            if (authorSplit.Length == 3)
                return new AuthorDto
                {
                    FirstName = $"{authorSplit[0]} {authorSplit[1]}",
                    LastName = authorSplit[2]
                };

            return new AuthorDto
            {
                FirstName = authorSplit[0],
                LastName = authorSplit[1]
            };
        }

        public static List<AuthorDto> ToAuthorDtos(this string authors)
        {
            if (authors.Contains(';'))
                return authors.Split("; ").Select(ToAuthorDto).ToList();

            return authors.Split(", ").Select(ToAuthorDto).ToList();
        }

        public static string ToAuthorsAsString(this List<Author> authors) => 
            string.Join(", ", authors.Select(a => $"{a.FirstName} {a.LastName}"));
    }
}
