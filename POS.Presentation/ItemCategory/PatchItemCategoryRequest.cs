namespace POS.Presentation.ItemCategory;

public record PatchItemCategoryRequest(
    Guid Id,
    string? Code = null,
    string? Name = null,
    string? Description = null
);