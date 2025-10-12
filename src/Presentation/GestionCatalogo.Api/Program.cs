using FluentValidation;
using FluentValidation.AspNetCore;
using GestionCatalogo.Application.Contracts.Persistence;
using GestionCatalogo.Application.Features.Products.Services;
using GestionCatalogo.Application.Features.Products.Validators;
using GestionCatalogo.Application.Mappings;
using GestionCatalogo.Infrastructure.Persistence;
using GestionCatalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE SERVICIOS ---

// 1. AÑADE LOS CONTROLADORES AL SERVICIO DE INYECCIÓN DE DEPENDENCIAS
// Si falta esta línea, la aplicación no sabe que existen los controladores.
builder.Services.AddControllers();

// --- Configuración de FluentValidation ---
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

// --- Configuración de Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Configuración de Entity Framework Core ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Configuración de AutoMapper ---
builder.Services.AddAutoMapper(typeof(MappingProfile));

// --- Configuración de Repositorios y Servicios ---
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// --- CONFIGURACIÓN DEL PIPELINE HTTP ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 2. MAPEA LOS CONTROLADORES A LAS RUTAS
// Si falta esta línea, los controladores están registrados pero no se usan.
app.MapControllers();

app.Run();