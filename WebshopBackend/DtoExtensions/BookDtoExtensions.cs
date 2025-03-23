using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class BookDtoExtensions
    {
        public static Book ToBook(this BookDto bookDto) => new Book
        {
            Id = bookDto.Id,
            Title = bookDto.Title.ToTitle(),
            Series = bookDto.Series?.ToSeries(),
            NumberInSeries = string.IsNullOrEmpty(bookDto.Series) ? null : bookDto.NumberInSeries,
            Authors = bookDto.Authors.ToAuthors(),
            Genre = bookDto.Genre.ToGenre(),
            ISBN = bookDto.ISBN,
            PublishedYear = new DateOnly(bookDto.PublishedYear, 1, 1),
            Publisher = bookDto.Publisher.ToPublisher(),
            Edition = bookDto.Edition.ToEdition(),
            Description = bookDto.Description,
            ImageUrl = bookDto.ImageUrl,
            Price = bookDto.Price,
            SalePercentage = CalculateSalePercentage(bookDto.Price, bookDto.SalePrice),
            AvailableQty = bookDto.AvailableQty
        };

        public static BookDto ToBookDto(this Book book) => new BookDto
        {
            Id = book.Id,
            ProductName = book.GetProductName(),
            Title = book.Title.TitleName,
            Series = book.Series?.SeriesName,
            NumberInSeries = book.Series == null ? null : book.NumberInSeries,
            Authors = book.Authors.ToAuthorsAsString(),
            Genre = book.Genre.GenreName,
            ISBN = book.ISBN,
            PublishedYear = book.PublishedYear.Year,
            Publisher = book.Publisher.PublisherName,
            Edition = book.Edition.EditionName,
            Description = book.Description,
            ImageUrl = book.ImageUrl,
            Price = book.Price,
            SalePrice = book.CalculateSalePrice(),
            AvailableQty = book.AvailableQty
        };

        private static int CalculateSalePercentage(decimal price, decimal? salePrice)
        {
            if (salePrice == null)
            {
                return 0;
            }
            return (int)((1 - salePrice / price) * 100);
        }

        private static decimal? CalculateSalePrice(this Book book)
        {
            if (book.SalePercentage == null)
            {
                return null;
            }
            return Math.Round(book.Price * (1M - (decimal)book.SalePercentage / 100), 2);
        }

        public static string GetProductName(this Book book)
        {
            return book.Title.TitleName 
                   + (book.Series == null ? "" : $"; {book.Series.SeriesName}, book #{book.NumberInSeries}") 
                   + $" ({book.Edition.EditionName})";
        }
    }
}
