using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace StoreApp.Infrastructre.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }
    }
}