using AutoMapper;
using GestionCatalogo.Application.Features.Products.Dtos;
using GestionCatalogo.Domain.Entities;

namespace GestionCatalogo.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo para obtener productos
        CreateMap<Product, ProductDto>();
        // Mapeo para crear un producto nuevo
        CreateMap<CreateProductDto, Product>();
    }
}