using LibraryWebAPI.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.DAL
{
    public class LibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDAL>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Ratings).Include(b => b.Reviews).ToListAsync();
        }

        public async Task<BookDAL> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Ratings).Include(b => b.Reviews)
                .Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddBookAsync(BookDAL bookDal)
        {
            await _context.Books.AddAsync(bookDal);
            await _context.SaveChangesAsync();
            return bookDal.Id;
        }

        public async Task<int> AddReviewAsync(ReviewDAL review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task<int> AddRatingAsync(RatingDAL rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return rating.Id;
        }

        public async Task<bool> TryToDeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
