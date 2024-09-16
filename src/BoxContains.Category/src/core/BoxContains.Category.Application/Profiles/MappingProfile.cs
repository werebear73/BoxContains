using AutoMapper;
using BoxContains.Category.Application.Features.Commands.CreateCategory;

namespace BoxContains.Category.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Domain.Category, CreateCategoryDto>().ReverseMap();
    }
}
