using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceApp.ViewModel;

public class ExpenseViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    [Required(ErrorMessage = "Valor é obrigatório")]
    public decimal Value { get; set; }

    [JsonPropertyName("categoryId")]
    [Required(ErrorMessage = "Categoria é obrigatório")]
    public Guid CategoryId { get; set; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Usuário é obrigatório")]
    public Guid UserId { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
