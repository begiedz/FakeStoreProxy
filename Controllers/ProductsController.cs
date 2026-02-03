using FakeStoreProxyApi.Models;
using FakeStoreProxyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProxyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetByCategory(CancellationToken ct)
    {
        var products = await _productsService.GetByCategoryAsync(ct);
        return Ok(products);
    }
}
