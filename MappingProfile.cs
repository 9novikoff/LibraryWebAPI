using AutoMapper;
using LibraryWebAPI.DAL.DALModels;
using LibraryWebAPI.DTOModels;

namespace LibraryWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDAL, Book>().ForMember(to => to.Rating,
                cf => cf.MapFrom(src => src.Ratings.Count != 0 ? src.Ratings.Sum(r => r.Score) / src.Ratings.Count : 0));
            CreateMap<BookDAL, ReducedBook>().ForMember(to => to.Rating,
                cf => cf.MapFrom(src => src.Ratings.Count != 0 ? src.Ratings.Sum(r => r.Score) / src.Ratings.Count : 0))
                .ForMember(to => to.ReviewsNumber,
                cf => cf.MapFrom(src => src.Reviews.Count)); ;
            CreateMap<BookDAL, PutBook>();
            CreateMap<PutBook, BookDAL>();
            CreateMap<RatingDAL, Rating>();
            CreateMap<Rating, RatingDAL>();
            CreateMap<Review, ReviewDAL>();
            CreateMap<ReviewDAL, Review>();
        }
    }
}
