using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
            // Post uzerinden UserRegistrationDto alinir biz onu User a cevirirz digerleri icin de bu gecerli
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
