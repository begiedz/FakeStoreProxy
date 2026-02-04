using FakeStoreProxy.Api.Requests;
using FakeStoreProxy.Api.Models;
using FakeStoreProxy.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProxyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;

    [HttpGet]
    public async Task<ActionResult<PagedResponse<Product>>> GetByName(
    [FromQuery] GetProductsByNameRequest request,
    CancellationToken ct = default)
    {
        var products = await _productsService.GetByNameAsync(request.Name, request.Page, request.PageSize, ct);

        return Ok(products);
    }
}
