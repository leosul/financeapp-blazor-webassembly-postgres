using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceApp.ViewModel;

public class CategoryViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
