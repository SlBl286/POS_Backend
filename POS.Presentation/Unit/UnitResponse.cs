using System;

namespace POS.Presentation.ItemCategory;

public record UnitResponse(
    string Id,
    string Code,
    string Name,
    DateTime UpdatedAt,
    DateTime CreatedAt
);
