// =================================================================
// 1. USING STATEMENTS - Importaciones necesarias
// =================================================================
using GestionCatalogo.Application.Contracts.Persistence;
using GestionCatalogo.Application.Features.Products.Services;
using GestionCatalogo.Application.Mappings;
using GestionCatalogo.Infrastructure.Persistence;
using GestionCatalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


// =================================================================
// 2. BUILDER SETUP - Creación del constructor de la aplicación
// =================================================================
var builder = WebApplication.CreateBuilder(args);


// =================================================================
// 3. SERVICES CONFIGURATION - Configuración de la Inyección de Dependencias (DI)
// Aquí le decimos a la aplicación qué clases usar cuando una interfaz es requerida.
// =================================================================

// Agrega el servicio de controladores para que la API sepa enrutarlos.
builder.Services.AddControllers();

// Agrega los servicios para la documentación de la API con Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Configuración de Entity Framework Core ---
// Registra el ApplicationDbContext y le dice que use SQL Server.
// La cadena de conexión "DefaultConnection" la obtiene del archivo appsettings.json.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Configuración de AutoMapper ---
// Escanea el ensamblado donde se encuentra MappingProfile y registra todos los perfiles de mapeo.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// --- Configuración de Repositorios y Servicios (Nuestro código) ---
// AddScoped: Se crea una instancia por cada petición HTTP. Es el ciclo de vida ideal para servicios que usan EF Core.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Repositorio genérico
builder.Services.AddScoped<IProductRepository, ProductRepository>();                   // Repositorio de Productos
builder.Services.AddScoped<IProductService, ProductService>();                         // Servicio de Productos


// =================================================================
// 4. APP BUILD - Construcción de la aplicación
// =================================================================
var app = builder.Build();


// =================================================================
// 5. HTTP PIPELINE CONFIGURATION - Configuración del pipeline de peticiones HTTP
// Define el orden en que las peticiones serán procesadas (middleware).
// =================================================================

// Condición: Si estamos en el entorno de desarrollo, habilitamos Swagger.
// Esto es una buena práctica para no exponer la documentación de la API en producción.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirige automáticamente las peticiones HTTP a HTTPS para mayor seguridad.
app.UseHttpsRedirection();

// Habilita la autenticación/autorización (aunque aún no la hemos configurado, es bueno tenerlo).
app.UseAuthorization();

// Mapea las rutas a los controladores que hemos creado.
app.MapControllers();


// =================================================================
// 6. RUN APP - Inicia la aplicación
// =================================================================
app.Run();