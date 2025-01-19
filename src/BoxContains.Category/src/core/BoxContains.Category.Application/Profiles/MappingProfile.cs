using AutoMapper;
using BoxContains.Category.Application.Features.Commands.CreateCategory;
using BoxContains.Category.Application.Features.Queries.GetAllCategories;
using BoxContains.Category.Application.Features.Queries.GetCategoryById;

namespace BoxContains.Category.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Domain.Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Domain.Category, GetAllCategoriesDto>().ReverseMap();
        CreateMap<Domain.Category, GetCategoryByIdDto>().ReverseMap();
    }
}
