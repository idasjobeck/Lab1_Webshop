using Microsoft.EntityFrameworkCore;
using WebshopBackend.Models;
using WebshopBackend.DtoExtensions;
using WebshopCore;
using Microsoft.AspNetCore.Identity;

namespace WebshopBackend.Data
{
    public class DummyDataForDb
    {
        private readonly WebshopDbContext _context;

        public DummyDataForDb(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task PopulateDatabaseAsync()
        {
            await PopulateProductDataAsync();
            RegisterDummyUsers();
            PopulateDummyOrderData();
        }

        // This method will ensure that the database is seeded with some initial product data
        private async Task PopulateProductDataAsync()
        {
            var products = GetProducts();

            //needs to be within a try catch block
            await AddDataToDbAsync(products);
        }

        // This method will ensure that the database is seeded with some dummy users
        private void RegisterDummyUsers()
        {

        }

        // This method will ensure that the database is seeded with some dummy orders
        private void PopulateDummyOrderData()
        {

        }

        private List<Book> GetProducts()
        {
            return new List<Book>
            {
                new Book() {Title = "The War of the Flowers".ToTitle(), Series = null, NumberInSeries = null, Genre = "Fantasy".ToGenre(), ISBN = "1-84149-189-6", PublishedYear = new DateOnly(2004, 1, 1), Publisher = "Orbit".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "A masterpiece of the imagination, THE WAR OF THE FLOWERS is a truly epic novel that once again pushes the boundaries of fantasy fiction into new and unexplored territory. In the great city, in the dimly lit office of an impossibly tall building, two creatures meet. Gold changes hands, and the master of the House of Hellebore gives an order: 'War is coming. The child must die.' In our own world, a young man discovers a manuscript written by his great uncle. It seems to be a novel - a strange fairytale of fantastic creatures and magical realms. But it is written as a diary ... as if the events were real ... as if his uncle had journeyed to another world. For the young man, the fantasy is about to become reality.", ImageUrl = "https://m.media-amazon.com/images/I/61LszR53mVL._SY522_.jpg", Price = 159, SalePercentage = null, AvailableQty = 2, Authors = "Tad Williams".ToAuthors()},
                new Book() {Title = "Armada".ToTitle(), Series = null, NumberInSeries = null, Genre = "Sci-fi".ToGenre(), ISBN = "978-0-09-958674-6", PublishedYear = new DateOnly(2016, 1, 1), Publisher = "Arrow Books".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "It's just another day of high school for Zack Lightman. He's daydreaming through another boring math class, with just one more month to go until graduation and freedom-if he can make it that long without getting suspended again. Then he glances out his classroom window and spots the flying saucer. At first, Zack thinks he's going crazy. A minute later, he's sure of it. Because the UFO he's staring at is straight out of the videogame he plays every night, a hugely popular online flight simulator called Armada-in which gamers just happen to be protecting the earth from alien invaders. But what Zack's seeing is all too real. And his skills-as well as those of millions of gamers across the world-are going to be needed to save the earth from what's about to befall it. Yet even as he and his new comrades scramble to prepare for the alien onslaught, Zack can't help thinking of all the science-fiction books, TV shows, and movies he grew up reading and watching, and wonder: Doesn't something about this scenario seem a little too... familiar? Armada is at once a rollicking, surprising thriller, a classic coming of age adventure, and an alien-invasion tale like nothing you've ever read before-one whose every page is infused with author Ernest Cline's trademark pop-culture savvy.", ImageUrl = "https://m.media-amazon.com/images/I/817f+kIsKYL._SY425_.jpg", Price = 179, SalePercentage = null, AvailableQty = 2, Authors = "Ernest Cline".ToAuthors()},
                new Book() {Title = "Ready Player One".ToTitle(), Series = null, NumberInSeries = null, Genre = "Sci-fi".ToGenre(), ISBN = "978-0-09-956043-2", PublishedYear = new DateOnly(2012, 1, 1), Publisher = "Arrow Books".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "It's the year 2044, and the real world has become an ugly place. We're out of oil. We've wrecked the climate. Famine, poverty, and disease are widespread. Like most of humanity, Wade Watts escapes this depressing reality by spending his waking hours jacked into the OASIS, a sprawling virtual utopia where you can be anything you want to be, where you can live and play and fall in love on any of ten thousand planets. And like most of humanity, Wade is obsessed by the ultimate lottery ticket that lies concealed within this alternate reality: OASIS founder James Halliday, who dies with no heir, has promised that control of the OASIS - and his massive fortune - will go to the person who can solve the riddles he has left scattered throughout his creation. For years, millions have struggled fruitlessly to attain this prize, knowing only that the riddles are based in the culture of the late twentieth century. And then Wade stumbles onto the key to the first puzzle. Suddenly, he finds himself pitted against thousands of competitors in a desperate race to claim the ultimate prize, a chase that soon takes on terrifying real-world dimensions - and that will leave both Wade and his world profoundly changed.", ImageUrl = "https://m.media-amazon.com/images/I/91Be3OR3f8L._SY466_.jpg", Price = 179, SalePercentage = null, AvailableQty = 2, Authors = "Ernest Cline".ToAuthors()},
                new Book() {Title = "Leviathan Wakes".ToTitle(), Series = "The Expanse".ToSeries(), NumberInSeries = 1, Genre = "Sci-fi".ToGenre(), ISBN = "978-1-84149-989-5", PublishedYear = new DateOnly(2012, 1, 1), Publisher = "Orbit".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "Humanity has colonised the solar system - Mars, the Moon, the Asteroid Belt and beyond - but the stars are still out of our reach. Jim Holden is an officer on an ice miner making runs from the rings of Saturn to the mining stations of the Belt. When he and his crew discover a derelict ship called the Scopuli, they suddenly find themselves in possession of a deadly secret. A secret that someone is willing to kill for, and on an unimaginable scale. War is coming to the system, unless Jim can find out who abandoned the ship and why. Detective Miller is looking for a girl. One girl in a system of billions, but her parents have money - and money talks. When the trail leads him to the Scopuli and Holden, they both realise this girl may hold the key to everything. Holden and Miller must thread the needle between the Earth government, the Outer Planet revolutionaries and secret corporations, and the odds are against them. But out in the Belt, the rules are different, and one small ship can change the fate of the universe.", ImageUrl = "https://m.media-amazon.com/images/I/818kGOTH9PL._SY466_.jpg", Price = 179, SalePercentage = null, AvailableQty = 2, Authors = "James S.A. Corey".ToAuthors()},
                new Book() {Title = "Armada".ToTitle(), Series = null, NumberInSeries = null, Genre = "Sci-fi".ToGenre(), ISBN = "978-1-780-89304-4", PublishedYear = new DateOnly(2015, 1, 1), Publisher = "Century".ToPublisher(), Edition = "Hardback".ToEdition(), Description = "It's just another day of high school for Zack Lightman. He's daydreaming through another boring math class, with just one more month to go until graduation and freedom-if he can make it that long without getting suspended again. Then he glances out his classroom window and spots the flying saucer. At first, Zack thinks he's going crazy. A minute later, he's sure of it. Because the UFO he's staring at is straight out of the videogame he plays every night, a hugely popular online flight simulator called Armada-in which gamers just happen to be protecting the earth from alien invaders. But what Zack's seeing is all too real. And his skills-as well as those of millions of gamers across the world-are going to be needed to save the earth from what's about to befall it. Yet even as he and his new comrades scramble to prepare for the alien onslaught, Zack can't help thinking of all the science-fiction books, TV shows, and movies he grew up reading and watching, and wonder: Doesn't something about this scenario seem a little too... familiar? Armada is at once a rollicking, surprising thriller, a classic coming of age adventure, and an alien-invasion tale like nothing you've ever read before-one whose every page is infused with author Ernest Cline's trademark pop-culture savvy.", ImageUrl = "https://m.media-amazon.com/images/I/817f+kIsKYL._SY425_.jpg", Price = 259, SalePercentage = null, AvailableQty = 2, Authors = "Ernest Cline".ToAuthors()},
                new Book() {Title = "The Eye of the World".ToTitle(), Series = "The Wheel of Time".ToSeries(), NumberInSeries = 1, Genre = "Fantasy".ToGenre(), ISBN = "978-1-85723-076-5", PublishedYear = new DateOnly(1991, 1, 1), Publisher = "Orbit".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "When their village is attacked by terrifying creatures, Rand al'Thor and his friends are forced to flee for their lives. An ancient evil is stirring, and its servants are scouring the land for the Dragon Reborn - the prophesised hero who can deliver the world from darkness. In this Age of myth and legend, the Wheel of Time turns. What was, what may be, and what is, may yet fall under the Shadow.", ImageUrl = "https://pictures.abebooks.com/isbn/9781857230765-us.jpg", Price = 179, SalePercentage = null, AvailableQty = 2, Authors = "Robert Jordan".ToAuthors()},
                new Book() {Title = "The Gathering Storm".ToTitle(), Series = "The Wheel of Time".ToSeries(), NumberInSeries = 12, Genre = "Fantasy".ToGenre(), ISBN = "978-1-84149-232-2", PublishedYear = new DateOnly(2010, 1, 1), Publisher = "Orbit".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "Tarmon Gai'don, the Last Battle, looms. And mankind is not ready. Rand al'Thor struggles to unite a fractured network of kingdoms and alliances in preparation for the Last Battle, as his allies watch in terror the shadow that seems to be growing within the heart of the Dragon Reborn himself. Egwene al'Vere is a captive of the White Tower and subject to the whims of their tyrannical leader. She works to hold together the disparate factions of Aes Sedai, as the days tick toward the Seanchan attack she knows is imminent. Her fight will prove the mettle of the Aes Sedai, and her conflict will decide the future of the White Tower - and possibly the world itself.", ImageUrl = "https://pictures.abebooks.com/isbn/9781841492322-us.jpg", Price = 199, SalePercentage = null, AvailableQty = 2, Authors = "Robert Jordan, Brandon Sanderson".ToAuthors()},
                new Book() {Title = "A Memory of Light".ToTitle(), Series = "The Wheel of Time".ToSeries(), NumberInSeries = 14, Genre = "Fantasy".ToGenre(), ISBN = "978-1-84149-871-3", PublishedYear = new DateOnly(2013, 1, 1), Publisher = "Orbit".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "In the Field of Merrilor the rulers of the nations gather to join behind Rand al'Thor, or to stop him from his plan to break the seals on the Dark One's prison - which may be a sign of his madness, or the last hope of humankind. Egwene, the Amyrlin Seat, leans toward the former. In Andor, the Trollocs seize Caemlyn. In the wolf dream, Perrin Aybara battles Slayer. Approaching Ebou Dar, Mat Cauthon plans to visit his wife Tuon, now Fortuona, Empress of the Seanchan. All humanity is in peril - and the outcome will be decided in Shayol Ghul itself. The Wheel is turning, and the Age is coming to its end. The Last Battle will determine the fate of the world . . .", ImageUrl = "https://pictures.abebooks.com/isbn/9781841498713-us.jpg", Price = 199, SalePercentage = null, AvailableQty = 2, Authors = "Robert Jordan, Brandon Sanderson".ToAuthors()},
                new Book() {Title = "The Hobbit".ToTitle(), Series = null, NumberInSeries = null, Genre = "Fantasy".ToGenre(), ISBN = "0-261-10221-4", PublishedYear = new DateOnly(1999, 1, 1), Publisher = "Harper Collins".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "This popular paperback edition of the classic work of fantasy, with a striking new black cover based on JRR Tolkien’s own design and featuring brand new reproductions of all his drawings and maps. Bilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, rarely travelling further than the pantry of his hobbit-hole in Bag End. But his contentment is disturbed when the wizard, Gandalf, and a company of thirteen dwarves arrive on his doorstep one day to whisk him away on an unexpected journey ‘there and back again’. They have a plot to raid the treasure hoard of Smaug the Magnificent, a large and very dangerous dragon... The prelude to The Lord of the Rings, The Hobbit has sold many millions of copies since its publication in 1937, establishing itself as one of the most beloved and influential books of the twentieth century.", ImageUrl = "https://m.media-amazon.com/images/I/71V2v2GtAtL._SY522_.jpg", Price = 159, SalePercentage = null, AvailableQty = 2, Authors = "J.R.R. Tolkien".ToAuthors()},
                new Book() {Title = "The Fellowship of the Ring".ToTitle(), Series = "The Fellowship of the Ring".ToSeries(), NumberInSeries = 1, Genre = "Fantasy".ToGenre(), ISBN = "0-261-10235-4", PublishedYear = new DateOnly(1999, 1, 1), Publisher = "Harper Collins".ToPublisher(), Edition = "Paperback".ToEdition(), Description = "In a sleepy village in the Shire, a young hobbit is entrusted with an immense task. He must make a perilous journey across Middle-earth to the Cracks of Doom, there to destroy the Ruling Ring of Power – the only thing that prevents the Dark Lord Sauron’s evil dominion. Thus begins J. R. R. Tolkien’s classic tale of adventure, which continues in The Two Towers and The Return of the King.", ImageUrl = "https://pictures.abebooks.com/isbn/9780261102354-us.jpg", Price = 159, SalePercentage = null, AvailableQty = 2, Authors = "J.R.R. Tolkien".ToAuthors()}
            };
        }

        private async Task AddDataToDbAsync(IEnumerable<Book> products)
        {
            //Each of the Get[Item]Async (e.g. GetTitleAsync etc.) extension methods check if [item] exists, uses existing [item] if it does, and creates a new [item] if it doesn't.
            
            foreach (var product in products)
            {
                //check if ISBN exists, and throw an exception if it does (as ISBN is a unique field)
                if (await _context.Books.AnyAsync(b => b.ISBN == product.ISBN))
                    throw new ArgumentException("ISBN already exists");

                //check that AvailableQty is greater than 0, and throw an exception if it isn't
                if (product.AvailableQty <= 0)
                    throw new ArgumentException("Available quantity must be greater than 0");

                product.Title = await _context.Titles.GetTitleAsync(product.Title.TitleName);
                product.Series = product.Series != null ? await _context.Series.GetSeriesAsync(product.Series.SeriesName) : null;
                product.Genre = await _context.Genres.GetGenreAsync(product.Genre.GenreName);
                product.Publisher = await _context.Publishers.GetPublisherAsync(product.Publisher.PublisherName);
                product.Edition = await _context.Editions.GetEditionAsync(product.Edition.EditionName);
                product.Authors = await product.Authors.GetAuthorsAsync(_context);

                _context.Books.Add(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
