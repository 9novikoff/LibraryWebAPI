using LibraryWebAPI.DAL;

namespace LibraryWebAPI.BLL
{
    public class LibraryService
    {
        private LibraryRepository _repository;

        public LibraryService(LibraryRepository repository)
        {
            _repository = repository;
        }

    }
}
