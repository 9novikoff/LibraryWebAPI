﻿namespace LibraryWebAPI.DTOModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
