namespace POS.Presentation.ItemCategory;

public record GetListRequest(
    string? Keyword,
    int Page = 0,
    int PageSize = 5
);