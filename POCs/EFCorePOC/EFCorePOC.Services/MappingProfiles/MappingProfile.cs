using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.Category.Name)))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.WebsiteURL, opt => opt.MapFrom(src => src.Website.AddressUrl))
                .ReverseMap()
                .ForMember(dest => dest.Website, opt => opt.Ignore())
                .ForMember(dest => dest.WebsiteId, opt => opt.Ignore())
                .ForMember(dest => dest.Publisher, opt => opt.Ignore())
                .ForMember(dest => dest.PublisherId, opt => opt.Ignore())
                .ForMember(dest => dest.BookCategories, opt => opt.Ignore());
        }
    }
}
