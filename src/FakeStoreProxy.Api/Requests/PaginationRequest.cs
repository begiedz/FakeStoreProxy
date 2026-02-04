using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FakeStoreProxy.Api.Requests;

public class PaginationRequest
{
    [DefaultValue(1)]
    [Range(1, int.MaxValue)]
    public int Page { get; init; } = 1;

    [DefaultValue(10)]
    [Range(1, 20)]
    public int PageSize { get; init; } = 10;
}
