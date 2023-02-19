namespace LibraryWebAPI.DAL.DALModels
{
    public class RatingDAL
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Score { get; set; }
    }
}
