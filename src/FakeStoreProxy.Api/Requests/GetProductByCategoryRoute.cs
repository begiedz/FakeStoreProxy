using System.ComponentModel.DataAnnotations;

namespace FakeStoreProxy.Api.Requests;

public class GetProductByCategoryRoute
{
    [Required]
    [MinLength(1)]
    [MaxLength(200)]
    public string Category { get; init; } = string.Empty;
}
