namespace POS.Presentation.ItemCategory;

public record CreateItemCategoryRequest(
    string Code,
    string Name,
    string? Description
);