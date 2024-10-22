using System;

namespace POS.Presentation.ItemCategory;

public record ItemCategoryResponse(
    string Id,
    string Code,
    string Name,
    string? Description,
    List<ItemItemCategoryReponse> Items,
    DateTime UpdatedAt,
    DateTime CreatedAt
);


public record ItemItemCategoryReponse(
    string Id,
    string ItemId
);