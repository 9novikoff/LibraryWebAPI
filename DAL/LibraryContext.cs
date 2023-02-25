using LibraryWebAPI.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<BookDAL> Books { get; set; }
        public DbSet<RatingDAL> Ratings { get; set; }
        public DbSet<ReviewDAL> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryLibraryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewDAL>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews);

            modelBuilder.Entity<RatingDAL>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Ratings);

            modelBuilder.Entity<BookDAL>().HasData(new List<BookDAL>()
            {
                new BookDAL()
                {
                    Id = 1, Title = "Don Quixote", Cover = "",
                    Content = "The plot revolves around the adventures of a member of the lowest nobility, an hidalgo from La Mancha named Alonso Quijano, who reads so many chivalric romances that he either loses or pretends to have lost his mind in order to become a knight-errant (caballero andante) to revive chivalry and serve his nation, under the name Don Quixote de la Mancha.",
                    Author = "Miguel de Cervantes", Genre = "Novel"
                },
                new BookDAL()
                {
                    Id = 2, Title = "Moby Dick", Cover = "",
                    Content = "The book is the sailor Ishmael's narrative of the maniacal quest of Ahab, captain of the whaling ship Pequod, for vengeance against Moby Dick, the giant white sperm whale that crippled him on the ship's previous voyage.",
                    Author = "Herman Melville", Genre = "Adventure fiction"
                },
                new BookDAL()
                {
                    Id = 3, Title = "The Great Gatsby", Cover = "",
                    Content = "The novel was inspired by a youthful romance Fitzgerald had with socialite Ginevra King, and the riotous parties he attended on Long Island's North Shore in 1922.",
                    Author = "Francis Scott Fitzgerald", Genre = "Novel"
                },
                new BookDAL()
                {
                    Id = 4, Title = "Hamlet", Cover = "",
                    Content = "Set in Denmark, the play depicts Prince Hamlet and his attempts to exact revenge against his uncle, Claudius, who has murdered Hamlet's father in order to seize his throne and marry Hamlet's mother.",
                    Author = "William Shakespeare", Genre = "Tragedy"
                },
                new BookDAL()
                {
                    Id = 5, Title = "The Odyssey", Cover = "",
                    Content = "It follows the Greek hero Odysseus, king of Ithaca, and his journey home after the Trojan War. After the war, which lasted ten years, his journey lasted for ten additional years, during which time he encountered many perils and all his crewmates were killed.",
                    Author = "Homer", Genre = "Poem"
                },
                new BookDAL()
                {
                    Id = 6, Title = "The Divine Comedy", Cover = "",
                    Content = "The poem's imaginative vision of the afterlife is representative of the medieval worldview as it existed in the Western Church by the 14th century.",
                    Author = "Dante Alighieri", Genre = "Poem"
                },
                new BookDAL()
                {
                    Id = 7, Title = "The Adventures of Huckleberry Finn", Cover = "",
                    Content = "It is told in the first person by Huckleberry Finn.",
                    Author = "Mark Twain", Genre = "Picaresque novel"
                },
                new BookDAL()
                {
                    Id = 8, Title = "Alice's Adventures in Wonderland", Cover = "",
                    Content ="It details the story of a young girl named Alice who falls through a rabbit hole into a fantasy world of anthropomorphic creatures.",
                    Author = "Lewis Carroll", Genre = "Fantasy"
                },
                new BookDAL()
                {
                    Id = 9, Title = "Gulliver's Travels", Cover = "",
                    Content = "Gulliver's Travels is the story of Lemuel Gulliver, a surgeon who takes to the seas. He completes many voyages without incident, but his final four journeys take him to some of the strangest lands on the planet, where he discovers the virtues and flaws in his own culture by comparing it with others.",
                    Author = "Jonathan Swift", Genre = "Fantasy"
                },
                new BookDAL()
                {
                    Id = 10, Title = "CLR via C#", Cover = "",
                    Content = "Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
                    Author = "Jeffrey Richter", Genre = "Fantasy"
                },

            });
        }
    }
}
