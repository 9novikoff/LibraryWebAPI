namespace LibraryWebAPI.DAL.DALModels
{
    public class BookDAL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public ICollection<ReviewDAL> Reviews { get; set; }
        public ICollection<RatingDAL> Ratings { get; set; }
    }
}
