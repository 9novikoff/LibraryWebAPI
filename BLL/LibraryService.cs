using AutoMapper;
using LibraryWebAPI.DAL;
using LibraryWebAPI.DAL.DALModels;
using LibraryWebAPI.DTOModels;

namespace LibraryWebAPI.BLL
{
    public class LibraryService
    {
        private readonly LibraryRepository _repository;
        private readonly IMapper _mapper;

        public LibraryService(LibraryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReducedBook>> GetAllBooksAsync()
        {
            var books = await _repository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<ReducedBook>>(books);
        }

        public async Task<IEnumerable<ReducedBook>> GetBooksOrderedByTitleAsync()
        {
            var books = await _repository.GetAllBooksAsync();
            books = books.OrderBy(x => x.Title).ToList();
            return _mapper.Map<IEnumerable<ReducedBook>>(books);
        }

        public async Task<IEnumerable<ReducedBook>> GetBooksOrderedByAuthorAsync()
        {
            var books = await _repository.GetAllBooksAsync();
            books = books.OrderBy(x => x.Author).ToList();
            return _mapper.Map<IEnumerable<ReducedBook>>(books);
        }

        public async Task<Book> GetDetailedBookByIdAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            return _mapper.Map<Book>(book);
        }

        public async Task<int> AddBookAsync(PutBook book)
        {
            var bookDal = _mapper.Map<BookDAL>(book);
            return await _repository.AddBookAsync(bookDal);
        }

        public async Task<bool> TryToDeleteAsync(int id, string? secret)
        {
            const string configPath = "appsettings.json";
            var key = new ConfigurationBuilder().AddJsonFile(configPath).Build().GetSection("Config")["Key"];

            if (key == null || !key.Equals(secret))
                return false;

            return await _repository.TryToDeleteBookAsync(id);
        }

        public async Task<int> AddReviewAsync(int bookId, Review review)
        {
            review.BookId = bookId;
            var reviewDal = _mapper.Map<ReviewDAL>(review);
            return await _repository.AddReviewAsync(reviewDal);
        }

        public async Task<int> AddRatingAsync(int bookId, Rating rating)
        {
            rating.BookId = bookId;
            var ratingDal = _mapper.Map<RatingDAL>(rating);
            return await _repository.AddRatingAsync(ratingDal);
        }

        public async Task<IEnumerable<ReducedBook>> GetTopBooksAsync()
        {
            const int size = 10;
            var booksDal = await _repository.GetAllBooksAsync();
            var topBooks = booksDal.Where(b => b.Reviews.Count > 10)
                .OrderBy(b => b.Ratings.Count != 0 ? b.Ratings.Sum(r => r.Score) / b.Ratings.Count : 0)
                .Take(size).ToList();

            return _mapper.Map<IEnumerable<ReducedBook>>(topBooks);
        }

        public async Task<IEnumerable<ReducedBook>> GetTopBooksByGenreAsync(string genre)
        {
            const int size = 10;
            var booksDal = await _repository.GetAllBooksAsync();
            var topBooks = booksDal.Where(b => b.Reviews.Count > 10 && b.Genre == genre)
                .OrderBy(b => b.Ratings.Count != 0 ? b.Ratings.Sum(r => r.Score) / b.Ratings.Count : 0)
                .Take(size).ToList();

            return _mapper.Map<IEnumerable<ReducedBook>>(topBooks);
        }

    }
}
