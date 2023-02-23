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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookDAL>().HasData(new List<BookDAL>()
            {
                new BookDAL()
                {
                    Id = 1, Title = "Don Quixote", Cover = "Hard",
                    Content =
                        "The plot revolves around the adventures of a member of the lowest nobility, an hidalgo from La Mancha named Alonso Quijano, who reads so many chivalric romances that he either loses or pretends to have lost his mind in order to become a knight-errant (caballero andante) to revive chivalry and serve his nation, under the name Don Quixote de la Mancha.",
                    Author = "Miguel de Cervantes", Genre = "Novel"
                },
                new BookDAL()
                {
                    Id = 2, Title = "Moby Dick", Cover = "Hard",
                    Content =
                        "The book is the sailor Ishmael's narrative of the maniacal quest of Ahab, captain of the whaling ship Pequod, for vengeance against Moby Dick, the giant white sperm whale that crippled him on the ship's previous voyage.",
                    Author = "Herman Melville", Genre = "Adventure fiction"
                }

            });
        }
    }
}
