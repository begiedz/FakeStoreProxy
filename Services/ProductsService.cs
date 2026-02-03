using FakeStoreProxyApi.Models;

namespace FakeStoreProxyApi.Services;

public class ProductsService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<Product>> GetByCategoryAsync(string category, CancellationToken ct)
    {
        var trimmedCategory = category.Trim();
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category), "category is required");


        var encodedCategory = Uri.EscapeDataString(trimmedCategory);

        string url = $"products/categoryy/{encodedCategory}";
        var res = await _httpClient.GetAsync(url, ct);

        if ((int)res.StatusCode >= 500)
            throw new HttpRequestException($"Provider error: {(int)res.StatusCode}");

        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            return new List<Product>();

        res.EnsureSuccessStatusCode();

        var json = await res.Content.ReadFromJsonAsync<List<Product>>(cancellationToken: ct);

        return json ?? new List<Product>();
    }
}
