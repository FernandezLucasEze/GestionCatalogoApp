using AutoMapper;
using GestionCatalogo.Application.Contracts.Persistence;
using GestionCatalogo.Application.Features.Products.Dtos;
using GestionCatalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionCatalogo.Application.Features.Products.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        var newProduct = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(newProduct);
    }

    public async Task<bool> UpdateProductAsync(int id, CreateProductDto updateProductDto)
    {
        var productToUpdate = await _productRepository.GetByIdAsync(id);
        if (productToUpdate == null) return false;

        _mapper.Map(updateProductDto, productToUpdate);
        await _productRepository.UpdateAsync(productToUpdate);
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productToDelete = await _productRepository.GetByIdAsync(id);
        if (productToDelete == null) return false;

        await _productRepository.DeleteAsync(productToDelete);
        return true;
    }
}