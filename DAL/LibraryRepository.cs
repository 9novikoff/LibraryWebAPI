using LibraryWebAPI.DAL.DALModels;

namespace LibraryWebAPI.DAL
{
    public class LibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<BookDAL> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public IEnumerable<BookDAL> GetAllBooksByGenre(string genre)
        {
            return _context.Books.Where(b => b.Genre == genre);
        }

        public IEnumerable<BookDAL> GetBookById(int id)
        {
            return _context.Books.Where(b => b.Id == id);
        }

        public void AddBook(BookDAL bookDal)
        {
            _context.Books.Add(bookDal);
        }

        public void AddReview(ReviewDAL review)
        {
            _context.Reviews.Add(review);
        }

        public void AddRating(RatingDAL rating)
        {
            _context.Ratings.Add(rating);
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if(book != null)
                _context.Books.Remove(book);
        }
    }
}
