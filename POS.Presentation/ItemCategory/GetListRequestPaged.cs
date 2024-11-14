namespace POS.Presentation.ItemCategory;

public record GetListPagedRequest(
    string? Keyword,
    int Page = 0,
    int PageSize = 5
);