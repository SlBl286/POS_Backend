namespace POS.Presentation.ItemCategory;

public record PutItemCategoryRequest(
    Guid Id,
    string Code,
    string Name,
    string? Description
);