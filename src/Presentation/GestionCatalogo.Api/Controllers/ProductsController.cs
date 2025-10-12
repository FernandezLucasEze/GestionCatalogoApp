using GestionCatalogo.Application.Features.Products.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionCatalogo.Api.Controllers;

// [ApiController] activa comportamientos específicos de API, como validaciones automáticas.
[ApiController]
// [Route] define la URL base para este controlador. "[controller]" se reemplaza por el nombre del controlador ("Products").
// La URL será: "api/products"
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // 1. Declaramos una dependencia del servicio que creamos antes.
    private readonly IProductService _productService;

    // 2. Usamos el constructor para inyectar la dependencia.
    // ASP.NET Core se encargará de crear una instancia de ProductService y pasarla aquí.
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // 3. Creamos el endpoint para obtener TODOS los productos.
    // [HttpGet] indica que este método responde a peticiones HTTP GET.
    // La URL completa será: GET api/products
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        // Ok() empaqueta la respuesta en un código de estado 200 (OK).
        return Ok(products);
    }

    // 4. Creamos el endpoint para obtener UN producto por su ID.
    // [HttpGet("{id}")] indica que la URL contendrá un parámetro.
    // La URL completa será: GET api/products/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        // Si el producto no se encuentra, devolvemos un 404 Not Found.
        if (product == null)
        {
            return NotFound();
        }

        // Si se encuentra, lo devolvemos con un 200 OK.
        return Ok(product);
    }
}