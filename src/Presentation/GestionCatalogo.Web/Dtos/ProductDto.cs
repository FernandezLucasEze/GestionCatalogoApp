using System.Text.Json.Serialization;

namespace GestionCatalogo.Web.Dtos;

public class ProductDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
}