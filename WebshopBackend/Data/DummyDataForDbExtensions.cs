using Microsoft.EntityFrameworkCore;
using WebshopBackend.Models;

namespace WebshopBackend.Data
{
    public static class DummyDataForDbExtensions
    {
        public static async Task<Title> GetTitleAsync(this IQueryable<Title> titles, string title) =>
            await titles.FirstOrDefaultAsync(t => t.TitleName == title) ?? new Title { TitleName = title };

        public static async Task<Series> GetSeriesAsync(this IQueryable<Series> series, string seriesName) => 
            await series.FirstOrDefaultAsync(s => s.SeriesName == seriesName) ?? new Series { SeriesName = seriesName };

        public static async Task<Genre> GetGenreAsync(this IQueryable<Genre> genres, string genre) =>
            await genres.FirstOrDefaultAsync(g => g.GenreName == genre) ?? new Genre { GenreName = genre };

        public static async Task<Publisher> GetPublisherAsync(this IQueryable<Publisher> publishers, string publisher) =>
            await publishers.FirstOrDefaultAsync(p => p.PublisherName == publisher) ?? new Publisher { PublisherName = publisher };

        public static async Task<Edition> GetEditionAsync(this IQueryable<Edition> editions, string edition) =>
            await editions.FirstOrDefaultAsync(e => e.EditionName == edition) ?? new Edition { EditionName = edition };

        public static async Task<List<Author>> GetAuthorsAsync(this List<Author> authors, WebshopDbContext context)
        {
            var authorsToReturn = new List<Author>();
            foreach (var author in authors)
            {
                var existingAuthor = await context.Authors.FirstOrDefaultAsync(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
                authorsToReturn.Add(existingAuthor ?? author);
            }
            return authorsToReturn;
        }
    }
}
