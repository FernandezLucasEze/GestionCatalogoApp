using AutoMapper;
using GestionCatalogo.Application.Contracts.Persistence;
using GestionCatalogo.Application.Features.Products.Dtos;
using GestionCatalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionCatalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    // Inyectamos el repositorio directamente y el mapper.
    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();
        // Mapeamos la lista de Product a una lista de ProductDto
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return Ok(productDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    // NUEVO ENDPOINT: Crear un producto
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
    {
        // Mapeamos del DTO a la entidad de dominio
        var product = _mapper.Map<Product>(createProductDto);
        var newProduct = await _productRepository.AddAsync(product);

        // Mapeamos de vuelta a un DTO para devolverlo al cliente
        var productDto = _mapper.Map<ProductDto>(newProduct);

        // Devolvemos un 201 Created con la ubicación del nuevo recurso y el objeto creado.
        return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
    }

    // NUEVO ENDPOINT: Actualizar un producto
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, CreateProductDto updateProductDto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        // Mapeamos los nuevos valores del DTO sobre la entidad existente
        _mapper.Map(updateProductDto, product);
        await _productRepository.UpdateAsync(product);

        // Devolvemos 204 No Content, que es el estándar para un PUT exitoso.
        return NoContent();
    }

    // NUEVO ENDPOINT: Eliminar un producto
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        await _productRepository.DeleteAsync(product);
        return NoContent();
    }
}