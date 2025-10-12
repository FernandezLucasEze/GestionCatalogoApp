using AutoMapper;
using GestionCatalogo.Application.Features.Products.Dtos;
using GestionCatalogo.Domain.Entities;
namespace GestionCatalogo.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
    }
}