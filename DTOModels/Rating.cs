using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DTOModels
{
    public class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Range(1.0, 5.0)]
        public decimal Score { get; set; }
    }
}
