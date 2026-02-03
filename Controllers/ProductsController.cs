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
    public async Task<ActionResult<List<Product>>> GetByCategory([FromQuery] string category, CancellationToken ct)
    {
     
        var products = await _productsService.GetByCategoryAsync(category, ct);

        if (products.Count == 0)
            return NoContent();

        return Ok(products);
    }
}
