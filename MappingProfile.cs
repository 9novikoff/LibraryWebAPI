using AutoMapper;
using LibraryWebAPI.DAL.DALModels;
using LibraryWebAPI.DTOModels;

namespace LibraryWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDAL, Book>();
            CreateMap<RatingDAL, Rating>();
            CreateMap<ReviewDAL, Review>();
        }
    }
}
