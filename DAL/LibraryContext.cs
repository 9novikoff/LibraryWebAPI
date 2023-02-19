using LibraryWebAPI.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<BookDAL> Books { get; set; }
        public DbSet<RatingDAL> Ratings { get; set; }
        public DbSet<ReviewDAL> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //SEED
        }
    }
}
