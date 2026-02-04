namespace FakeStoreProxy.Api.Models;

public sealed class PagedResponse<T>
{
    public required List<T> Items { get; init; }
    public required PaginationMetadata Pagination { get; init; }
}
