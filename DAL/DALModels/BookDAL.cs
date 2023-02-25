using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DAL.DALModels
{
    public class BookDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<ReviewDAL> Reviews { get; set; }
        public virtual ICollection<RatingDAL> Ratings { get; set; }
    }
}
