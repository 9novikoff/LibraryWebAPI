using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DAL.DALModels
{
    public class ReviewDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public int BookId { get; set; }
        public string Reviewer { get; set; }
    }
}
