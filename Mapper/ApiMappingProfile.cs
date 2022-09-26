using AutoMapper;
using News.API.DTO;
using News.API.Mongodb.Entities;

namespace News.API.Mapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<EditorNews, NewsDto>();
    }
}